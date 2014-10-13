using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using WinForms = System.Windows.Forms;

namespace JiraBugger
{
    public partial class MainWindow : Window
    {
        CounterWindow counterWindow = new CounterWindow();

        #region minimize to tray
        WinForms.NotifyIcon notifyIcon = new WinForms.NotifyIcon();
        private void InitState()
        {
            notifyIcon.Icon = new System.Drawing.Icon("resources/Icon.ico");
            notifyIcon.Visible = true;
            var menu = new System.Windows.Forms.ContextMenu();
            menu.MenuItems.Add("Setting", changeSettingEvent);
            menu.MenuItems.Add("Exit", ExitEvent);
            notifyIcon.ContextMenu = menu;
            notifyIcon.DoubleClick += delegate
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };

            var localJiraAccount = SettingStorage.LoadSettings();
            if (string.IsNullOrWhiteSpace(localJiraAccount.User) 
                || string.IsNullOrWhiteSpace(localJiraAccount.Password))
            {
                this.Hide();
                App.SettingsWindow.Show();
            }
        }
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
                counterWindow.Show();
            }

            base.OnStateChanged(e);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!App.ListWindowAlreadyShutdown)
            {
                counterWindow.Show();
                this.Hide();
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
        
        private void ExitEvent(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Current.Shutdown();
            App.ListWindowAlreadyShutdown = true;
        }
        private void changeSettingEvent(object sender, EventArgs e)
        {
            App.SettingsWindow = new SettingsWindow();
            App.SettingsWindow.Show();
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            var localJiraAccount = SettingStorage.LoadSettings();
            App.BaseUrl = localJiraAccount.BaseUrl;
            App.ProjectKey = localJiraAccount.ProjectKey;
            App.BugFilter = localJiraAccount.BugFilter;
            App.StoryFilter = localJiraAccount.StoryFilter;
            
            InitState();
            App.Notifications.Top = SystemParameters.WorkArea.Top + App.NotificationTopOffset;
            App.Notifications.Left = 
                SystemParameters.WorkArea.Left + SystemParameters.WorkArea.Width - App.NotificationLeftOffset;
            
            this.IssueListView.DataContext = App.IssuesViewModel;

            ReadLocalData(BuggerIssueType.Bug, App.IssuesViewModel.MyBugsModel);
            App.IssuesViewModel.ActiveBugs = App.IssuesViewModel.MyBugsModel.Count(i => i.Status.ToLowerInvariant().Equals("open"));
            App.IssuesViewModel.ResolvedBugs = App.IssuesViewModel.MyBugsModel.Count(i => i.Status.ToLowerInvariant().Equals("resolved"));
            ReadLocalData(BuggerIssueType.Story, App.IssuesViewModel.MyStoriesModel);

            ReadRemoteDate(null, null);

            var myTimer = new System.Timers.Timer();
            myTimer.Elapsed += ReadRemoteDate;
            myTimer.Interval = 30 * 1000; //5*60*1000;
            myTimer.Enabled = true;
            counterWindow.Show();
        }

        // this pop up feature is for bugs only
        private void ReadLocalData(BuggerIssueType issueType, ObservableCollectionWrapper<Issue> collection)
        {
            var localData = IssueStorage.LoadSettings(issueType);
            foreach (var item in localData)
            {
                var data = item.Split('_');
                collection.Add(new Issue
                {
                    Summary = data[2],
                    Status = data[1],
                    Key = data[0]
                });
            }
        }

        private void ReadRemoteDate(object source, ElapsedEventArgs e)
        {
            new Thread(App.GetMyIssues).Start();
        }

        private void MyStoriesListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var issueKey = (this.MyStoriesListView.SelectedItem as Issue).Key;
            System.Diagnostics.Process.Start(string.Format("{0}/browse/{1}", App.BaseUrl, issueKey));
        }

        private void MyBugsListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var issueKey = (this.MyBugsListView.SelectedItem as Issue).Key;
            System.Diagnostics.Process.Start(string.Format("{0}/browse/{1}", App.BaseUrl, issueKey));
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
