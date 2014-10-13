using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace JiraBugger
{
    public partial class NotifiactionsWindow : Window
    {
        private const byte MAX_NOTIFICATIONS = 4;
        private int count;
        public NotificationsModel NotificationsModel = new NotificationsModel();
        private readonly NotificationsModel buffer = new NotificationsModel();

        public NotifiactionsWindow()
        {
            InitializeComponent();
            NotificationsControl.DataContext = NotificationsModel;
        }

        public void AddNotification(Notification notification)
        {
            notification.Id = count++;
            if (NotificationsModel.Count + 1 > MAX_NOTIFICATIONS)
            {
                buffer.Add(notification);
            }
            else
            {
                NotificationsModel.Add(notification);
            }

            //Show window if there're notifications
            if (NotificationsModel.Count > 0 && !IsActive)
            {
                Show();
            }
        }

        public void RemoveNotification(Notification notification)
        {
            if (NotificationsModel.Contains(notification))
            {
                NotificationsModel.Remove(notification);
            }

            if (buffer.Count > 0)
            {
                NotificationsModel.Add(buffer[0]);
                buffer.RemoveAt(0);
            }

            //Close window if there's nothing to show
            if (NotificationsModel.Count < 1)
            {
                Hide();
            }
        }

        private void NotificationWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height != 0.0)
            {
                return;
            }
            var element = sender as Grid;
            RemoveNotification(NotificationsModel.First(n => n.Id == Int32.Parse(element.Tag.ToString())));
        }

        private void Title_Click(object sender, RoutedEventArgs e)
        {
            var issueKey = (sender as Button).Tag.ToString().Split(' ')[0];
            System.Diagnostics.Process.Start(string.Format("{0}/browse/{1}", App.BaseUrl, issueKey));
        }

        private void Summary_Click(object sender, RoutedEventArgs e)
        {
            var issueKey = (sender as Button).Tag.ToString().Split(' ')[0];
            System.Diagnostics.Process.Start(string.Format("{0}/browse/{1}", App.BaseUrl, issueKey));
        }
    }
}