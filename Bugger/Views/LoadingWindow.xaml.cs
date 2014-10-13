using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace JiraBugger
{
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            
            var story = (Storyboard)this.FindResource("LoadingStoryboard");
            story.Completed += story_Completed;
            story.Begin();
        }

        void story_Completed(object sender, EventArgs e)
        {
            var localJiraAccount = SettingStorage.LoadSettings();

            if (App.IsJiraAccountValid(localJiraAccount))
            {
                App.ListWindowAlreadyShutdown = false;
                App.ListWindow = new MainWindow();
                App.ListWindow.Show();
            }
            else
            {
                App.ListWindowAlreadyShutdown = true;
                App.SettingsWindow.Show();
            }
            this.Hide();
        }
    }
}