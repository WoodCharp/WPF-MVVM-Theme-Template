using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ViewContentControls
{
    public class ViewContentSectionItem : Control
    {
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string),
                typeof(ViewContentSectionItem), new PropertyMetadata("Item header text"));

        public double HeaderFontSize
        {
            get { return (double)GetValue(HeaderFontSizeProperty); }
            set { SetValue(HeaderFontSizeProperty, value); }
        }
        public static readonly DependencyProperty HeaderFontSizeProperty =
            DependencyProperty.Register("HeaderFontSize", typeof(double),
                typeof(ViewContentSectionItem), new PropertyMetadata(14.0));


        public FrameworkElement Content
        {
            get { return (FrameworkElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(FrameworkElement),
                typeof(ViewContentSectionItem), new PropertyMetadata(null));


        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }
        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.Register("ErrorText", typeof(string),
                typeof(ViewContentSectionItem), new PropertyMetadata("Some great error message text that is long and boring"));

        public double ErrorTextFontSize
        {
            get { return (double)GetValue(ErrorTextFontSizeProperty); }
            set { SetValue(ErrorTextFontSizeProperty, value); }
        }
        public static readonly DependencyProperty ErrorTextFontSizeProperty =
            DependencyProperty.Register("ErrorTextFontSize", typeof(double),
                typeof(ViewContentSectionItem), new PropertyMetadata(14.0));

        public SolidColorBrush ErrorTextColorBrush
        {
            get { return (SolidColorBrush)GetValue(ErrorTextColorBrushProperty); }
            set { SetValue(ErrorTextColorBrushProperty, value); }
        }
        public static readonly DependencyProperty ErrorTextColorBrushProperty =
            DependencyProperty.Register("ErrorTextColorBrush", typeof(SolidColorBrush), typeof(ViewContentSectionItem),
                new PropertyMetadata(new SolidColorBrush(Colors.DarkRed)));

        public SolidColorBrush ErrorBorderColorBrush
        {
            get { return (SolidColorBrush)GetValue(ErrorBorderColorBrushProperty); }
            set { SetValue(ErrorBorderColorBrushProperty, value); }
        }
        public static readonly DependencyProperty ErrorBorderColorBrushProperty =
            DependencyProperty.Register("ErrorBorderColorBrush", typeof(SolidColorBrush),
                typeof(ViewContentSectionItem), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

        public bool IsErrorTextVisible
        {
            get { return (bool)GetValue(IsErrorTextVisibleProperty); }
            set { SetValue(IsErrorTextVisibleProperty, value); }
        }
        public static readonly DependencyProperty IsErrorTextVisibleProperty =
            DependencyProperty.Register("IsErrorTextVisible", typeof(bool),
                typeof(ViewContentSectionItem), new PropertyMetadata(false));

        static ViewContentSectionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewContentSectionItem),
                new FrameworkPropertyMetadata(typeof(ViewContentSectionItem)));
        }
    }
}