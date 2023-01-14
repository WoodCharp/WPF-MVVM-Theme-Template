using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace IconToggleButtonControl
{
    public class IconToggleButton : Control
    {
        public SolidColorBrush UncheckedColorBrush
        {
            get { return (SolidColorBrush)GetValue(UncheckedColorBrushProperty); }
            set { SetValue(UncheckedColorBrushProperty, value); }
        }
        public static readonly DependencyProperty UncheckedColorBrushProperty =
            DependencyProperty.Register("UncheckedColorBrush", typeof(SolidColorBrush),
                typeof(IconToggleButton), new PropertyMetadata(new SolidColorBrush(Colors.Gray), UncheckedColorBrushChanged));

        private static void UncheckedColorBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconToggleButton) ((IconToggleButton)d).UpdateColors();
        }

        public SolidColorBrush UncheckedHoverBrush
        {
            get { return (SolidColorBrush)GetValue(UncheckedHoverBrushProperty); }
            set { SetValue(UncheckedHoverBrushProperty, value); }
        }
        public static readonly DependencyProperty UncheckedHoverBrushProperty =
            DependencyProperty.Register("UncheckedHoverBrush", typeof(SolidColorBrush),
                typeof(IconToggleButton), new PropertyMetadata(new SolidColorBrush(Colors.Gray), UncheckedHoverBrushChanged));

        private static void UncheckedHoverBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconToggleButton) ((IconToggleButton)d).UpdateColors();
        }

        public SolidColorBrush CheckedColorBrush
        {
            get { return (SolidColorBrush)GetValue(CheckedColorBrushProperty); }
            set { SetValue(CheckedColorBrushProperty, value); }
        }
        public static readonly DependencyProperty CheckedColorBrushProperty =
            DependencyProperty.Register("CheckedColorBrush", typeof(SolidColorBrush),
                typeof(IconToggleButton), new PropertyMetadata(new SolidColorBrush(Colors.Gray), CheckedColorBrushChanged));

        private static void CheckedColorBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconToggleButton) ((IconToggleButton)d).UpdateColors();
        }

        public SolidColorBrush CheckedHoverBrush
        {
            get { return (SolidColorBrush)GetValue(CheckedHoverBrushProperty); }
            set { SetValue(CheckedHoverBrushProperty, value); }
        }
        public static readonly DependencyProperty CheckedHoverBrushProperty =
            DependencyProperty.Register("CheckedHoverBrush", typeof(SolidColorBrush),
                typeof(IconToggleButton), new PropertyMetadata(new SolidColorBrush(Colors.Gray), CheckedHoverBrushChanged));

        private static void CheckedHoverBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconToggleButton) ((IconToggleButton)d).UpdateColors();
        }

        public SolidColorBrush DisabledBrush
        {
            get { return (SolidColorBrush)GetValue(DisabledBrushProperty); }
            set { SetValue(DisabledBrushProperty, value); }
        }
        public static readonly DependencyProperty DisabledBrushProperty =
            DependencyProperty.Register("DisabledBrush", typeof(SolidColorBrush),
                typeof(IconToggleButton), new PropertyMetadata(new SolidColorBrush(Colors.LightGray), DisabledBrushChanged));

        private static void DisabledBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconToggleButton) ((IconToggleButton)d).UpdateColors();
        }

        public Geometry CurrentIcon
        {
            get { return (Geometry)GetValue(CurrentIconProperty); }
            set { SetValue(CurrentIconProperty, value); }
        }
        public static readonly DependencyProperty CurrentIconProperty =
            DependencyProperty.Register("CurrentIcon", typeof(Geometry),
                typeof(IconToggleButton), new PropertyMetadata(null));

        public Geometry UncheckedIcon
        {
            get { return (Geometry)GetValue(UncheckedIconProperty); }
            set { SetValue(UncheckedIconProperty, value); }
        }
        public static readonly DependencyProperty UncheckedIconProperty =
            DependencyProperty.Register("UncheckedIcon", typeof(Geometry),
                typeof(IconToggleButton), new PropertyMetadata(null));

        public Geometry CheckedIcon
        {
            get { return (Geometry)GetValue(CheckedIconProperty); }
            set { SetValue(CheckedIconProperty, value); }
        }
        public static readonly DependencyProperty CheckedIconProperty =
            DependencyProperty.Register("CheckedIcon", typeof(Geometry),
                typeof(IconToggleButton), new PropertyMetadata(null));

        public ICommand UncheckedCommand
        {
            get { return (ICommand)GetValue(UncheckedCommandProperty); }
            set { SetValue(UncheckedCommandProperty, value); }
        }
        public static readonly DependencyProperty UncheckedCommandProperty =
            DependencyProperty.Register("UncheckedCommand", typeof(ICommand),
                typeof(IconToggleButton), new PropertyMetadata(null));

        public ICommand CheckedCommand
        {
            get { return (ICommand)GetValue(CheckedCommandProperty); }
            set { SetValue(CheckedCommandProperty, value); }
        }
        public static readonly DependencyProperty CheckedCommandProperty =
            DependencyProperty.Register("CheckedCommand", typeof(ICommand),
                typeof(IconToggleButton), new PropertyMetadata(null));

        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register("IconMargin", typeof(Thickness),
                typeof(IconToggleButton), new PropertyMetadata(new Thickness(2)));


        static IconToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconToggleButton), new FrameworkPropertyMetadata(typeof(IconToggleButton)));
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool),
                typeof(IconToggleButton), new PropertyMetadata(false, IsCheckedChanged));
        private static void IsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var itb = (IconToggleButton)d;
            if (itb != null)
            {
                if (itb.IsChecked) itb.CheckedCommand?.Execute(itb);
                else itb.UncheckedCommand?.Execute(itb);

                itb.UpdateColors();
            }
        }

        public bool HoverEnabled
        {
            get { return (bool)GetValue(HoverEnabledProperty); }
            set { SetValue(HoverEnabledProperty, value); }
        }
        public static readonly DependencyProperty HoverEnabledProperty =
            DependencyProperty.Register("HoverEnabled", typeof(bool),
                typeof(IconToggleButton), new PropertyMetadata(true));

        public bool AnimationsEnabled
        {
            get { return (bool)GetValue(AnimationsEnabledProperty); }
            set { SetValue(AnimationsEnabledProperty, value); }
        }
        public static readonly DependencyProperty AnimationsEnabledProperty =
            DependencyProperty.Register("AnimationsEnabled", typeof(bool),
                typeof(IconToggleButton), new PropertyMetadata(true));

        private DoubleAnimation scaleDownAnim;
        private DoubleAnimation scaleUpAnim;
        private ScaleTransform? scale;

        private void UpdateColors()
        {
            CurrentIcon = IsChecked ? CheckedIcon : UncheckedIcon;

            if (!IsEnabled)
            {
                Foreground = DisabledBrush;
                return;
            }

            if (IsMouseOver) Foreground = IsChecked ? CheckedHoverBrush : UncheckedHoverBrush;
            else Foreground = IsChecked ? CheckedColorBrush : UncheckedColorBrush;

        }

        public IconToggleButton()
        {
            scaleDownAnim = new DoubleAnimation();
            scaleDownAnim.To = 0.95;
            scaleDownAnim.Duration = new Duration(TimeSpan.FromMilliseconds(100));

            scaleUpAnim = new DoubleAnimation();
            scaleUpAnim.To = 1;
            scaleUpAnim.Duration = new Duration(TimeSpan.FromMilliseconds(100));

            Loaded += IB_Loaded;
            IsEnabledChanged += IB_IsEnabledChanged;
        }


        private void IB_Loaded(object sender, RoutedEventArgs e)
        {
            var template = this.Template;
            scale = (ScaleTransform)template.FindName("iconScale", this);

            UpdateColors();
        }

        private void IB_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateColors();
        }


        private void AnimateOut()
        {
            if (scale != null)
            {
                scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleUpAnim);
                scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleUpAnim);
            }
        }

        private void AnimateIn()
        {
            if (scale != null)
            {
                scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleDownAnim);
                scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleDownAnim);
            }
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (AnimationsEnabled) AnimateIn();
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            if (AnimationsEnabled) AnimateOut();

            IsChecked = !IsChecked;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            if (HoverEnabled) UpdateColors();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            if (AnimationsEnabled) AnimateOut();

            if (HoverEnabled) UpdateColors();
        }
    }
}
