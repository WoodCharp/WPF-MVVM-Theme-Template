using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WPFMVVMTemplate.MVVM.Commands;

namespace WPFMVVMTemplate.Notifications
{
    public partial class NotificationControl : UserControl
    {
        private DoubleAnimation _showAnimation;
        private DoubleAnimation _hideAnimation;

        public static readonly DependencyProperty CloseProperty =
        DependencyProperty.Register("CloseCommand", typeof(ICommand),
            typeof(NotificationControl), new UIPropertyMetadata(null));
        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseProperty); }
            set { SetValue(CloseProperty, value); }
        }

        public NotificationControl()
        {
            InitializeComponent();

            _showAnimation = new DoubleAnimation();
            _showAnimation.AccelerationRatio = 0.3;
            _showAnimation.DecelerationRatio = 0.7;
            _showAnimation.Duration = TimeSpan.FromMilliseconds(250);
            _showAnimation.To = 30;

            _hideAnimation = new DoubleAnimation();
            _hideAnimation.AccelerationRatio = 0.7;
            _hideAnimation.DecelerationRatio = 0.3;
            _hideAnimation.Duration = TimeSpan.FromMilliseconds(250);
            _hideAnimation.To = 0;

            CloseCommand = new ActionCommand(Hide);
        }

        public void Show(string notification)
        {
            tbText.Text = notification;

            grid.BeginAnimation(HeightProperty, _showAnimation);
        }

        public void Hide()
        {
            grid.BeginAnimation(HeightProperty, _hideAnimation);
        }
    }
}