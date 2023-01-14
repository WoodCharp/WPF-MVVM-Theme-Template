using System.Threading.Tasks;
using System.Windows;

namespace WPFMVVMTemplate.Notifications
{
    public class Notification
    {
        private static MessageControl? _messageControl;
        private static LoadingControl? _loadingControl;
        private static NotificationControl? _notificationControl;

        public static void Initialzie(MessageControl messageControl, 
            LoadingControl loadingControl, NotificationControl notificationControl)
        {
            _messageControl = messageControl;
            _loadingControl = loadingControl;
            _notificationControl = notificationControl;
        }

        public static async Task ShowLoading(int ms)
        {
            if (_loadingControl == null) return;

            await _loadingControl.Show(true);
            await Task.Delay(ms);
            await _loadingControl.Hide();
        }

        public static async Task<MessageBoxResult> ShowMessage(string title, string message,
            MessageBoxButton mbb = MessageBoxButton.OK, MessageBoxImage mbi = MessageBoxImage.None)
        {
            if (_messageControl == null) return MessageBoxResult.None;
            if (_loadingControl != null) await _loadingControl.Show(false);

            await Task.Delay(500);
            var result = await _messageControl.Show(title, message, mbb, mbi);

            if (_loadingControl != null) await _loadingControl.Hide();

            return result;
        }

        public static void ShowNotification(string notification)
        {
            _notificationControl?.Show(notification);
        }

    }
}