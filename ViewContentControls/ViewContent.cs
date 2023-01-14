using System.Windows;
using System.Windows.Controls;

namespace ViewContentControls
{
    public class ViewContent : Control
    {
        public FrameworkElement ControlsContent
        {
            get { return (FrameworkElement)GetValue(ControlsContentProperty); }
            set { SetValue(ControlsContentProperty, value); }
        }
        public static readonly DependencyProperty ControlsContentProperty =
            DependencyProperty.Register("ControlsContent", typeof(FrameworkElement),
                typeof(ViewContent), new PropertyMetadata(null));

        public Orientation ControlsOrientation
        {
            get { return (Orientation)GetValue(ControlsOrientationProperty); }
            set { SetValue(ControlsOrientationProperty, value); }
        }
        public static readonly DependencyProperty ControlsOrientationProperty =
            DependencyProperty.Register("ControlsOrientation", typeof(Orientation),
                typeof(ViewContent), new PropertyMetadata(Orientation.Horizontal));

        public FrameworkElement Content
        {
            get { return (FrameworkElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(FrameworkElement),
                typeof(ViewContent), new PropertyMetadata(null));

        static ViewContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewContent), new FrameworkPropertyMetadata(typeof(ViewContent)));
        }
    }
}