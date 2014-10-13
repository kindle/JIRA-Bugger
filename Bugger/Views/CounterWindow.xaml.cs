using System.Windows;
using System.Windows.Input;

namespace JiraBugger
{
    public partial class CounterWindow : Window
    {
        public CounterWindow()
        {
            InitializeComponent();
            this.Left = SystemParameters.WorkArea.Width/2 - 40;
            this.DataContext = App.IssuesViewModel;
            this.MouseLeftButtonDown += Counter_MouseLeftButtonDown;
        }

        void Counter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }  
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.ListWindow.Show();
        }

    }
}
