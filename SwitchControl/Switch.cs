using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SwitchControl
{
    public class Switch : Control
    {
        public SolidColorBrush ColorBrush
        {
            get { return (SolidColorBrush)GetValue(ColorBrushProperty); }
            set { SetValue(ColorBrushProperty, value); }
        }
        public static readonly DependencyProperty ColorBrushProperty =
            DependencyProperty.Register("ColorBrush", typeof(SolidColorBrush),
                typeof(Switch), new PropertyMetadata(new SolidColorBrush(Colors.Black), ColorBrushChanged));

        private static void ColorBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Switch) ((Switch)d).UpdateColors();
        }

        public SolidColorBrush DisabledBrush
        {
            get { return (SolidColorBrush)GetValue(DisabledBrushProperty); }
            set { SetValue(DisabledBrushProperty, value); }
        }
        public static readonly DependencyProperty DisabledBrushProperty =
            DependencyProperty.Register("DisabledBrush", typeof(SolidColorBrush),
                typeof(Switch), new PropertyMetadata(new SolidColorBrush(Colors.LightGray), DisabledBrushChanged));

        private static void DisabledBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Switch) ((Switch)d).UpdateColors();
        }

        public SolidColorBrush UncheckedBrush
        {
            get { return (SolidColorBrush)GetValue(UncheckedBrushProperty); }
            set { SetValue(UncheckedBrushProperty, value); }
        }
        public static readonly DependencyProperty UncheckedBrushProperty =
            DependencyProperty.Register("UncheckedBrush", typeof(SolidColorBrush),
                typeof(Switch), new PropertyMetadata(new SolidColorBrush(Colors.Red), UncheckedBrushChanged));

        private static void UncheckedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Switch) ((Switch)d).UpdateColors();
        }

        public SolidColorBrush CheckedBrush
        {
            get { return (SolidColorBrush)GetValue(CheckedBrushProperty); }
            set { SetValue(CheckedBrushProperty, value); }
        }
        public static readonly DependencyProperty CheckedBrushProperty =
            DependencyProperty.Register("CheckedBrush", typeof(SolidColorBrush),
                typeof(Switch), new PropertyMetadata(new SolidColorBrush(Colors.Green), CheckedBrushChanged));

        private static void CheckedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Switch) ((Switch)d).UpdateColors();
        }

        public ICommand CheckedCommand
        {
            get { return (ICommand)GetValue(CheckedCommandProperty); }
            set { SetValue(CheckedCommandProperty, value); }
        }
        public static readonly DependencyProperty CheckedCommandProperty =
            DependencyProperty.Register("CheckedCommand", typeof(ICommand),
                typeof(Switch), new PropertyMetadata(null));


        public ICommand UncheckedCommand
        {
            get { return (ICommand)GetValue(UncheckedCommandProperty); }
            set { SetValue(UncheckedCommandProperty, value); }
        }
        public static readonly DependencyProperty UncheckedCommandProperty =
            DependencyProperty.Register("UncheckedCommand", typeof(ICommand),
                typeof(Switch), new PropertyMetadata(null));

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool),
                typeof(Switch), new PropertyMetadata(false, IsCheckedChanged));

        private static void IsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Switch) ((Switch)d).OnIsCheckedChanged();
        }

        public void OnIsCheckedChanged()
        {
            Animate();
            UpdateColors();

            if (IsChecked) CheckedCommand?.Execute(null);
            else UncheckedCommand?.Execute(null);
        }

        public bool UseSingleColor
        {
            get { return (bool)GetValue(UseSingleColorProperty); }
            set { SetValue(UseSingleColorProperty, value); }
        }
        public static readonly DependencyProperty UseSingleColorProperty =
            DependencyProperty.Register("UseSingleColor", typeof(bool),
                typeof(Switch), new PropertyMetadata(false, UseSingleColorChanged));

        private static void UseSingleColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Switch) ((Switch)d).UpdateColors();
        }



        static Switch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Switch), new FrameworkPropertyMetadata(typeof(Switch)));
        }

        public void UpdateColors()
        {
            if (ellipse != null)
            {
                if (IsEnabled)
                {
                    Foreground = ColorBrush;

                    if (UseSingleColor)
                        ellipse.Fill = ColorBrush;
                    else
                        ellipse.Fill = IsChecked ? CheckedBrush : UncheckedBrush;
                }
                else
                {
                    Foreground = DisabledBrush;
                    ellipse.Fill = DisabledBrush;
                }
            }
        }


        private DoubleAnimation onAnim;
        private DoubleAnimation offAnim;
        private Ellipse? ellipse;

        public Switch()
        {
            onAnim = new DoubleAnimation();
            onAnim.To = 25;
            onAnim.Duration = new Duration(TimeSpan.FromMilliseconds(250));
            onAnim.AccelerationRatio = 0.7;
            onAnim.DecelerationRatio = 0.3;

            offAnim = new DoubleAnimation();
            offAnim.To = 0;
            offAnim.Duration = new Duration(TimeSpan.FromMilliseconds(250));
            offAnim.AccelerationRatio = 0.7;
            offAnim.DecelerationRatio = 0.3;

            Loaded += TB_Loaded;
            IsEnabledChanged += TB_IsEnabledChanged;
        }

        public void Animate()
        {
            if (IsChecked) AnimateOn();
            else AnimateOff();
        }

        private void AnimateOff()
        {
            if (ellipse != null)
            {
                ellipse.BeginAnimation(Canvas.LeftProperty, offAnim);
                UpdateColors();
            }
        }

        private void AnimateOn()
        {
            if (ellipse != null)
            {
                ellipse.BeginAnimation(Canvas.LeftProperty, onAnim);
                UpdateColors();
            }
        }

        private void TB_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateColors();
        }

        private void TB_Loaded(object sender, RoutedEventArgs e)
        {
            var template = this.Template;
            ellipse = (Ellipse)template.FindName("ellipse", this);
            Animate();
            UpdateColors();
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            IsChecked = !IsChecked;
        }
    }
}