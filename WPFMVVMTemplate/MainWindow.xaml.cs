using System.Windows;
using System.Windows.Input;
using WPFMVVMTemplate.Notifications;

namespace WPFMVVMTemplate
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            Notification.Initialzie(messageControl, loadingControl, notificationControl);
        }

        private void MouseDragWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;

                var point = Mouse.GetPosition(null);

                Top = point.Y;
                Left = point.X - (Width / 2);

            }
            else if (e.LeftButton == MouseButtonState.Pressed && WindowState == WindowState.Normal) DragMove();
        }
    }
}