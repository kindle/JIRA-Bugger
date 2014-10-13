using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using JiraBugger.Utilities;
using TechTalk.JiraRestClient;

namespace JiraBugger
{
    public partial class App : Application
    {
        private const string MutexName = "Bailin.JIRA.Bugger";
        public static LoadingWindow LoadingWindow;
        public static SettingsWindow SettingsWindow = new SettingsWindow();
        public static MainWindow ListWindow;
        public static JiraClient JiraClient;
        public static IssuesViewModel IssuesViewModel = new IssuesViewModel();
        public static bool ListWindowAlreadyShutdown;

        public static readonly NotifiactionsWindow Notifications = new NotifiactionsWindow();
        public const double NotificationTopOffset = 20;
        public const double NotificationLeftOffset = 300;

        public static string BaseUrl { get; set; }
        public static string ProjectKey { get; set; }
        public static string BugFilter { get; set; }
        public static string StoryFilter { get; set; }

        public static bool IsJiraAccountValid(LocalJiraAccount localJiraAccount)
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(localJiraAccount.BaseUrl) ||
                string.IsNullOrWhiteSpace(localJiraAccount.ProjectKey) ||
                string.IsNullOrWhiteSpace(localJiraAccount.User) ||
                string.IsNullOrWhiteSpace(localJiraAccount.Password)
                )
            {
                result = false;
            }
            else
            {
                JiraClient = new JiraClient(
                    localJiraAccount.BaseUrl,
                    localJiraAccount.User,
                    localJiraAccount.Password);
                try
                {
                    JiraClient.GetServerInfo();
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }

            return result;
        }

        [STAThread]
        public static void Main()
        {
            bool isNew;

            using (new Mutex(false, MutexName, out isNew))
            {
                if (!isNew)
                {
                    return;
                }

                var app = new App();

                App.LoadingWindow = new LoadingWindow();

                try
                {
                    app.Run(App.LoadingWindow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public static void GetMyIssues()
        {
            App.UpdateIssues(BuggerIssueType.Bug, App.BugFilter, App.IssuesViewModel.MyBugsModel);
            App.UpdateIssues(BuggerIssueType.Story, App.StoryFilter, App.IssuesViewModel.MyStoriesModel);
        }

        public static void UpdateIssues(BuggerIssueType issueType, string filter, ObservableCollectionWrapper<Issue> collection)
        {
            IEnumerable<TechTalk.JiraRestClient.Issue> issues = null;
            try
            {
                issues = App.JiraClient.GetIssues(App.ProjectKey, filter, issueType.ToString());
            }
            catch
            {
                return;
            }
            var myIssues = new List<TechTalk.JiraRestClient.Issue>();

            foreach (var issue in issues)
            {
                if (issue.fields != null && issue.fields.assignee != null)
                {
                    if (issueType.Equals(BuggerIssueType.Story))
                    {
                        if (issue.fields.status.name.Equals("in progress", StringComparison.InvariantCultureIgnoreCase)
                            || issue.fields.status.name.Equals("resolved", StringComparison.InvariantCultureIgnoreCase)
                            || issue.fields.status.name.Equals("open", StringComparison.InvariantCultureIgnoreCase))
                        {
                            myIssues.Add(issue);
                        }
                    }
                    else
                    {
                        if (issue.fields.status.name.Equals("open", StringComparison.InvariantCultureIgnoreCase)
                            || issue.fields.status.name.Equals("Resolved", StringComparison.InvariantCultureIgnoreCase))
                        {
                            myIssues.Add(issue);
                        }
                    }
                }
            }
            myIssues.Sort();

            // update active/resolved 
            if (issueType.Equals(BuggerIssueType.Bug))
            {
                App.IssuesViewModel.ActiveBugs = myIssues.Count(i => i.fields.status.name.ToLowerInvariant().Equals("open"));
                App.IssuesViewModel.ResolvedBugs = myIssues.Count(i => i.fields.status.name.ToLowerInvariant().Equals("resolved"));
            }
            // Check changes and pop up notifications
            var localData = IssueStorage.LoadSettings(issueType);
            foreach (var item in myIssues)
            {
                var key = item.key;
                var status = item.fields.status.name;
                var summary = item.fields.summary;

                if (localData.Count(v => v.Contains(key)) > 0)
                {
                    // changes
                    if (!localData.Contains(string.Format("{0}_{1}_{2}", key, status, summary)))
                    {
                        App.Notifications.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                            App.Notifications.AddNotification(new Notification
                            {
                                Title = "Issue got changed!",
                                ImageUrl = "pack://application:,,,/Resources/NotificationChange.jpg",
                                Message = string.Format("{0} {1}", key, summary)
                            })));
                    }
                }
                else
                {
                    //new gift
                    App.Notifications.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                        App.Notifications.AddNotification(new Notification
                        {
                            Title = "You've got a gift!",
                            ImageUrl = "pack://application:,,,/Resources/NotificationGift.png",
                            Message = string.Format("{0} {1}", key, summary)
                        })));
                }
            }

            // Update UI data
            App.ListWindow.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                collection.Clear();
                foreach (var item in myIssues)
                {
                    collection.Add(new Issue
                    {
                        Summary = item.fields.summary,
                        Status = item.fields.status.name,
                        Key = item.key
                    });
                }
            }));
            // Update local data
            var dataToSaveLocally = myIssues.Select(item =>
                string.Format("{0}_{1}_{2}",
                item.key,
                item.fields.status.name,
                item.fields.summary)).ToList();
            IssueStorage.SaveSettings(dataToSaveLocally, issueType);
        }
    }
}