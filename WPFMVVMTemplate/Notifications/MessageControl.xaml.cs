using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WPFMVVMTemplate.MVVM.Commands;

namespace WPFMVVMTemplate.Notifications
{
    public partial class MessageControl : UserControl
    {
        private Geometry _gNone;
        private Geometry _gError;
        private Geometry _gQuestion;
        private Geometry _gExclamation;
        private Geometry _gInformation;

        private DoubleAnimation _showAnimation;
        private DoubleAnimation _hideAnimation;

        private bool _wait = false;
        private MessageBoxResult _result;
        private MessageBoxButton _button;

        public static readonly DependencyProperty OkProperty =
        DependencyProperty.Register("OkCommand", typeof(ICommand),
            typeof(MessageControl), new UIPropertyMetadata(null));
        public ICommand OkCommand
        {
            get { return (ICommand)GetValue(OkProperty); }
            set { SetValue(OkProperty, value); }
        }

        public static readonly DependencyProperty NoProperty =
        DependencyProperty.Register("NoCommand", typeof(ICommand),
            typeof(MessageControl), new UIPropertyMetadata(null));
        public ICommand NoCommand
        {
            get { return (ICommand)GetValue(NoProperty); }
            set { SetValue(NoProperty, value); }
        }

        public static readonly DependencyProperty CancelProperty =
        DependencyProperty.Register("CancelCommand", typeof(ICommand),
            typeof(MessageControl), new UIPropertyMetadata(null));
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelProperty); }
            set { SetValue(CancelProperty, value); }
        }

        public MessageControl()
        {
            InitializeComponent();

            OkCommand = new ActionCommand(Ok);
            NoCommand = new ActionCommand(No);
            CancelCommand = new ActionCommand(Cancel);

            _showAnimation = new DoubleAnimation();
            _showAnimation.Duration = TimeSpan.FromMilliseconds(150);
            _showAnimation.RepeatBehavior = new RepeatBehavior(1.0);
            _showAnimation.AutoReverse = false;
            _showAnimation.AccelerationRatio = 0.7;
            _showAnimation.DecelerationRatio = 0.3;
            _showAnimation.To = 1;

            _hideAnimation = new DoubleAnimation();
            _hideAnimation.Duration = TimeSpan.FromMilliseconds(150);
            _hideAnimation.RepeatBehavior = new RepeatBehavior(1.0);
            _hideAnimation.AutoReverse = false;
            _hideAnimation.AccelerationRatio = 0.7;
            _hideAnimation.DecelerationRatio = 0.3;
            _hideAnimation.To = 0;

            _gNone = Geometry.Empty;
            _gError = Geometry.Parse("m16.5 33.6 7.5-7.5 7.5 7.5 2.1-2.1-7.5-7.5 7.5-7.5-2.1-2.1-7.5 7.5-7.5-7.5-2.1 2.1 7.5 7.5-7.5 7.5ZM24 44q-4.1 0-7.75-1.575-3.65-1.575-6.375-4.3-2.725-2.725-4.3-6.375Q4 28.1 4 24q0-4.15 1.575-7.8 1.575-3.65 4.3-6.35 2.725-2.7 6.375-4.275Q19.9 4 24 4q4.15 0 7.8 1.575 3.65 1.575 6.35 4.275 2.7 2.7 4.275 6.35Q44 19.85 44 24q0 4.1-1.575 7.75-1.575 3.65-4.275 6.375t-6.35 4.3Q28.15 44 24 44Zm0-3q7.1 0 12.05-4.975Q41 31.05 41 24q0-7.1-4.95-12.05Q31.1 7 24 7q-7.05 0-12.025 4.95Q7 16.9 7 24q0 7.05 4.975 12.025Q16.95 41 24 41Zm0-17Z");
            _gQuestion = Geometry.Parse("M24.2 35.65q.8 0 1.35-.55t.55-1.35q0-.8-.55-1.35t-1.35-.55q-.8 0-1.35.55t-.55 1.35q0 .8.55 1.35t1.35.55Zm-1.75-7.3h2.95q0-1.3.325-2.375T27.75 23.5q1.55-1.3 2.2-2.55.65-1.25.65-2.75 0-2.65-1.725-4.25t-4.575-1.6q-2.45 0-4.325 1.225T17.25 16.95l2.65 1q.55-1.4 1.65-2.175 1.1-.775 2.6-.775 1.7 0 2.75.925t1.05 2.375q0 1.1-.65 2.075-.65.975-1.9 2.025-1.5 1.3-2.225 2.575-.725 1.275-.725 3.375ZM24 44q-4.1 0-7.75-1.575-3.65-1.575-6.375-4.3-2.725-2.725-4.3-6.375Q4 28.1 4 24q0-4.15 1.575-7.8 1.575-3.65 4.3-6.35 2.725-2.7 6.375-4.275Q19.9 4 24 4q4.15 0 7.8 1.575 3.65 1.575 6.35 4.275 2.7 2.7 4.275 6.35Q44 19.85 44 24q0 4.1-1.575 7.75-1.575 3.65-4.275 6.375t-6.35 4.3Q28.15 44 24 44Zm0-3q7.1 0 12.05-4.975Q41 31.05 41 24q0-7.1-4.95-12.05Q31.1 7 24 7q-7.05 0-12.025 4.95Q7 16.9 7 24q0 7.05 4.975 12.025Q16.95 41 24 41Zm0-17Z");
            _gExclamation = Geometry.Parse("M24 34q.7 0 1.175-.475.475-.475.475-1.175 0-.7-.475-1.175Q24.7 30.7 24 30.7q-.7 0-1.175.475-.475.475-.475 1.175 0 .7.475 1.175Q23.3 34 24 34Zm-1.35-7.65h3V13.7h-3ZM24 44q-4.1 0-7.75-1.575-3.65-1.575-6.375-4.3-2.725-2.725-4.3-6.375Q4 28.1 4 23.95q0-4.1 1.575-7.75 1.575-3.65 4.3-6.35 2.725-2.7 6.375-4.275Q19.9 4 24.05 4q4.1 0 7.75 1.575 3.65 1.575 6.35 4.275 2.7 2.7 4.275 6.35Q44 19.85 44 24q0 4.1-1.575 7.75-1.575 3.65-4.275 6.375t-6.35 4.3Q28.15 44 24 44Zm.05-3q7.05 0 12-4.975T41 23.95q0-7.05-4.95-12T24 7q-7.05 0-12.025 4.95Q7 16.9 7 24q0 7.05 4.975 12.025Q16.95 41 24.05 41ZM24 24Z");
            _gInformation = Geometry.Parse("M22.65 34h3V22h-3ZM24 18.3q.7 0 1.175-.45.475-.45.475-1.15t-.475-1.2Q24.7 15 24 15q-.7 0-1.175.5-.475.5-.475 1.2t.475 1.15q.475.45 1.175.45ZM24 44q-4.1 0-7.75-1.575-3.65-1.575-6.375-4.3-2.725-2.725-4.3-6.375Q4 28.1 4 23.95q0-4.1 1.575-7.75 1.575-3.65 4.3-6.35 2.725-2.7 6.375-4.275Q19.9 4 24.05 4q4.1 0 7.75 1.575 3.65 1.575 6.35 4.275 2.7 2.7 4.275 6.35Q44 19.85 44 24q0 4.1-1.575 7.75-1.575 3.65-4.275 6.375t-6.35 4.3Q28.15 44 24 44Zm.05-3q7.05 0 12-4.975T41 23.95q0-7.05-4.95-12T24 7q-7.05 0-12.025 4.95Q7 16.9 7 24q0 7.05 4.975 12.025Q16.95 41 24.05 41ZM24 24Z");
        }

        private void Ok()
        {
            if (_button == MessageBoxButton.OK || _button == MessageBoxButton.OKCancel)
                _result = MessageBoxResult.OK;
            else _result = MessageBoxResult.Yes;

            _wait = false;
        }

        private void No()
        {
            _result = MessageBoxResult.No;
            _wait = false;
        }

        private void Cancel()
        {
            _result = MessageBoxResult.Cancel;
            _wait = false;
        }

        public async Task<MessageBoxResult> Show(string title, string message, MessageBoxButton mbb, MessageBoxImage img = MessageBoxImage.None)
        {
            _wait = true;
            _button = mbb;
            tbTitle.Text = title;
            tbMessage.Text = message;

            switch (mbb)
            {
                case MessageBoxButton.YesNo:
                    ibCancel.Visibility = Visibility.Collapsed;
                    ibYes.Visibility = Visibility.Visible;
                    ibNo.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    ibCancel.Visibility = Visibility.Visible;
                    ibYes.Visibility = Visibility.Visible;
                    ibNo.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.OK:
                    ibCancel.Visibility = Visibility.Collapsed;
                    ibYes.Visibility = Visibility.Visible;
                    ibNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.OKCancel:
                    ibCancel.Visibility = Visibility.Visible;
                    ibYes.Visibility = Visibility.Visible;
                    ibNo.Visibility = Visibility.Collapsed;
                    break;
            }

            icon.Visibility = Visibility.Visible;

            switch ((int)img)
            {
                //None
                case 0:
                    icon.Visibility = Visibility.Collapsed;
                    break;
                //Error, Hand, Stop
                case 16:
                    icon.Data = _gError;
                    break;
                //Question
                case 32:
                    icon.Data = _gQuestion;
                    break;
                //Exclamation, Warning
                case 48:
                    icon.Data = _gExclamation;
                    break;
                //Asterisk, Information
                case 64:
                    icon.Data = _gInformation;
                    break;
            }

            Visibility = Visibility.Visible;

            scale.BeginAnimation(ScaleTransform.ScaleXProperty, _showAnimation);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, _showAnimation);
            await Task.Delay(150);

            while (_wait) { await Task.Delay(100); }

            scale.BeginAnimation(ScaleTransform.ScaleXProperty, _hideAnimation);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, _hideAnimation);
            await Task.Delay(150);

            Visibility = Visibility.Collapsed;
            return _result;
        }
    }
}