using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace IconButtonControl
{
    public class IconButton : Control
    {
        public SolidColorBrush ColorBrush
        {
            get { return (SolidColorBrush)GetValue(ColorBrushProperty); }
            set { SetValue(ColorBrushProperty, value); }
        }
        public static readonly DependencyProperty ColorBrushProperty =
            DependencyProperty.Register("ColorBrush", typeof(SolidColorBrush),
                typeof(IconButton), new PropertyMetadata(new SolidColorBrush(Colors.Black), ColorBrushChanged));

        private static void ColorBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconButton) ((IconButton)d).UpdateColors();
        }

        public SolidColorBrush HoverBrush
        {
            get { return (SolidColorBrush)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }
        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.Register("HoverBrush", typeof(SolidColorBrush),
                typeof(IconButton), new PropertyMetadata(new SolidColorBrush(Colors.Gray), HoverBrushChanged));

        private static void HoverBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconButton) ((IconButton)d).UpdateColors();
        }

        public SolidColorBrush DisabledBrush
        {
            get { return (SolidColorBrush)GetValue(DisabledBrushProperty); }
            set { SetValue(DisabledBrushProperty, value); }
        }
        public static readonly DependencyProperty DisabledBrushProperty =
            DependencyProperty.Register("DisabledBrush", typeof(SolidColorBrush),
                typeof(IconButton), new PropertyMetadata(new SolidColorBrush(Colors.LightGray), DisabledBrushChanged));

        private static void DisabledBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is IconButton) ((IconButton)d).UpdateColors();
        }

        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry),
                typeof(IconButton), new PropertyMetadata(null));


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand),
                typeof(IconButton), new PropertyMetadata(null));


        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }
        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register("IconMargin", typeof(Thickness),
                typeof(IconButton), new PropertyMetadata(new Thickness(2)));

        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
        }

        public bool HoverEnabled
        {
            get { return (bool)GetValue(HoverEnabledProperty); }
            set { SetValue(HoverEnabledProperty, value); }
        }
        public static readonly DependencyProperty HoverEnabledProperty =
            DependencyProperty.Register("HoverEnabled", typeof(bool),
                typeof(IconButton), new PropertyMetadata(true));

        public bool AnimationsEnabled
        {
            get { return (bool)GetValue(AnimationsEnabledProperty); }
            set { SetValue(AnimationsEnabledProperty, value); }
        }
        public static readonly DependencyProperty AnimationsEnabledProperty =
            DependencyProperty.Register("AnimationsEnabled", typeof(bool),
                typeof(IconButton), new PropertyMetadata(true));

        private DoubleAnimation scaleDownAnim;
        private DoubleAnimation scaleUpAnim;
        private ScaleTransform? scale;

        private void UpdateColors()
        {
            if (IsEnabled) Foreground = IsMouseOver ? HoverBrush : ColorBrush;
            else Foreground = DisabledBrush;
        }

        public IconButton()
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

            Command?.Execute(this);
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