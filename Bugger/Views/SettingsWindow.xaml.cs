using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace JiraBugger
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            LoadJiraAccount();
        }

        private void LoadJiraAccount()
        {
            var localJiraAccount = SettingStorage.LoadSettings();
            if (!string.IsNullOrEmpty(localJiraAccount.BaseUrl))
            {
                this.BaseUrl.Text = localJiraAccount.BaseUrl;
            }
            if (!string.IsNullOrEmpty(localJiraAccount.ProjectKey))
            {
                this.Project.Text = localJiraAccount.ProjectKey;
            }
            this.User.Text = localJiraAccount.User;
            this.Password.Password = localJiraAccount.Password;
            if (localJiraAccount.BugFilter == null || localJiraAccount.BugFilter.ToLowerInvariant().Equals("all"))
            {
                this.IsBugAll.IsChecked = true;
            }
            else if (localJiraAccount.BugFilter.ToLowerInvariant().Equals("reporter"))
            {
                this.IsBugReporter.IsChecked = true;
            }
            else
            {
                this.IsBugOwner.IsChecked = true;
            }
            if (localJiraAccount.StoryFilter == null || localJiraAccount.StoryFilter.ToLowerInvariant().Equals("all"))
            {
                this.IsStoryAll.IsChecked = true;
            }
            else if (localJiraAccount.StoryFilter.ToLowerInvariant().Equals("reporter"))
            {
                this.IsStoryReporter.IsChecked = true;
            }
            else
            {
                this.IsStoryOwner.IsChecked = true;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var localJiraAccount = new LocalJiraAccount
            {
                BaseUrl = this.BaseUrl.Text,
                ProjectKey = this.Project.Text,
                User = this.User.Text,
                Password = this.Password.Password,
                BugFilter = this.IsBugAll.IsChecked == true ? "all" : 
                    this.IsBugReporter.IsChecked == true ? "reporter" : "owner",
                StoryFilter = this.IsStoryAll.IsChecked == true ? "all" : 
                    this.IsStoryReporter.IsChecked == true ? "reporter" : "owner"
            };

            if(App.IsJiraAccountValid(localJiraAccount))
            {
                SettingStorage.SaveSettings(localJiraAccount);
                App.BaseUrl = localJiraAccount.BaseUrl;
                App.ProjectKey = localJiraAccount.ProjectKey;
                App.BugFilter = localJiraAccount.BugFilter;
                App.StoryFilter = localJiraAccount.StoryFilter;
                this.Hide();
                if (App.ListWindow == null)
                {
                    App.ListWindow = new MainWindow();
                }
                App.ListWindow.Show();
                new Thread(App.GetMyIssues).Start();
            }
            else
            {
                MessageBox.Show("Invalid Jira Account!");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (App.ListWindow == null)
            {
                Application.Current.Shutdown();
            }
            else
            {
                this.Close();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }  
        }
    }
}
