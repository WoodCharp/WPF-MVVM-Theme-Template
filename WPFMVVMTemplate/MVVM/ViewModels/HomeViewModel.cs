using System.Windows;
using System.Windows.Input;
using WPFMVVMTemplate.MVVM.Commands;
using WPFMVVMTemplate.Notifications;
using WPFMVVMTemplate.Properties.Languages;

namespace WPFMVVMTemplate.MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private AppManager _app;

        public ICommand ShowLoadingCommand { get; }
        public ICommand ShowMessageCommand { get; }
        public ICommand ShowNotificationCommand { get; }

        public HomeViewModel(AppManager app)
        {
            _app = app;

            ShowLoadingCommand = new ActionCommand(ShowLoading);
            ShowMessageCommand = new ActionCommand(ShowMessage);
            ShowNotificationCommand = new ActionCommand(ShowNotification);
        }

        private void ShowNotification()
        {
            Notification.ShowNotification(Lang.notificationText);
        }

        private async void ShowMessage()
        {
            await Notification.ShowMessage(Lang.messageTitle, Lang.messageText, MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);
        }

        private async void ShowLoading()
        {
            await Notification.ShowLoading(5000);
        }
    }
}