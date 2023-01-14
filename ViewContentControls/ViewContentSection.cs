using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace ViewContentControls
{
    public class ViewContentSection : Control
    {
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string),
                typeof(ViewContentSection), new PropertyMetadata("Section header text"));

        public SolidColorBrush CollapseButtonBrush
        {
            get { return (SolidColorBrush)GetValue(CollapseButtonBrushProperty); }
            set { SetValue(CollapseButtonBrushProperty, value); }
        }
        public static readonly DependencyProperty CollapseButtonBrushProperty =
            DependencyProperty.Register("CollapseButtonBrush", typeof(SolidColorBrush),
                typeof(ViewContentSection), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public FrameworkElement Content
        {
            get { return (FrameworkElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(FrameworkElement),
                typeof(ViewContentSection), new PropertyMetadata(null));

        public double CloseAnimationHeight
        {
            get { return (double)GetValue(CloseAnimationHeightProperty); }
            set { SetValue(CloseAnimationHeightProperty, value); }
        }
        public static readonly DependencyProperty CloseAnimationHeightProperty =
            DependencyProperty.Register("CloseAnimationHeight", typeof(double),
                typeof(ViewContentSection), new PropertyMetadata(30.0));


        public bool CollapseButtonVisible
        {
            get { return (bool)GetValue(CollapseButtonVisibleProperty); }
            set { SetValue(CollapseButtonVisibleProperty, value); }
        }
        public static readonly DependencyProperty CollapseButtonVisibleProperty =
            DependencyProperty.Register("CollapseButtonVisible", typeof(bool),
                typeof(ViewContentSection), new PropertyMetadata(true));

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool),
                typeof(ViewContentSection), new PropertyMetadata(true, IsOpenChanged));
        private static void IsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var section = (ViewContentSection)d;
            if (section != null) section.Animate();
        }

        public void Animate()
        {
            if (!IsOpen) CloseAnimation();
            else OpenAnimation();
        }

        private void OpenAnimation()
        {
            _openAnimation.To = startHeight;
            BeginAnimation(HeightProperty, _openAnimation);
        }

        private void CloseAnimation()
        {
            startHeight = ActualHeight;
            Height = ActualHeight;
            DoubleAnimation openAnimation = new DoubleAnimation(CloseAnimationHeight, new Duration(TimeSpan.FromMilliseconds(200)));
            BeginAnimation(HeightProperty, openAnimation);
        }

        private DoubleAnimation _openAnimation;
        private double startHeight;

        public ViewContentSection()
        {
            _openAnimation = new DoubleAnimation();
            _openAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(200));
            _openAnimation.Completed += openAnimation_Completed;
            Loaded += VCS_Loaded;
        }

        private void VCS_Loaded(object sender, RoutedEventArgs e)
        {
            startHeight = ActualHeight;
        }

        private void openAnimation_Completed(object? sender, EventArgs e)
        {
            Height = double.NaN;
        }


        static ViewContentSection()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewContentSection),
                new FrameworkPropertyMetadata(typeof(ViewContentSection)));
        }
    }
}
