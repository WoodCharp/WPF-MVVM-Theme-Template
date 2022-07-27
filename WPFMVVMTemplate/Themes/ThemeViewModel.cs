using System.Windows.Media;
using WPFMVVMTemplate.MVVM.ViewModels;

namespace WPFMVVMTemplate.Themes
{
    public class ThemeViewModel : ViewModelBase
    {
        private Color _windowTitleBarColor;
        public Color WindowTitleBarColor
        {
            get { return _windowTitleBarColor; }
            set
            {
                _windowTitleBarColor = value;
                OnPropertyChanged(nameof(WindowTitleBarColor));
                OnPropertyChanged(nameof(WindowTitleBarBrush));
            }
        }
        public SolidColorBrush WindowTitleBarBrush => new SolidColorBrush(WindowTitleBarColor);

        private Color _windowBackgroundColor;
        public Color WindowBackgroundColor
        {
            get { return _windowBackgroundColor; }
            set
            {
                _windowBackgroundColor = value;
                OnPropertyChanged(nameof(WindowBackgroundColor));
                OnPropertyChanged(nameof(WindowBackgroundBrush));
            }
        }
        public SolidColorBrush WindowBackgroundBrush => new SolidColorBrush(WindowBackgroundColor);



        private Color _foregroundColor;
        public Color ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                _foregroundColor = value;
                OnPropertyChanged(nameof(ForegroundColor));
                OnPropertyChanged(nameof(ForegroundBrush));
            }
        }
        public SolidColorBrush ForegroundBrush => new SolidColorBrush(ForegroundColor);

        private Color _foregroundHoverColor;
        public Color ForegroundHoverColor
        {
            get { return _foregroundHoverColor; }
            set
            {
                _foregroundHoverColor = value;
                OnPropertyChanged(nameof(ForegroundHoverColor));
                OnPropertyChanged(nameof(ForegroundHoverBrush));
            }
        }
        public SolidColorBrush ForegroundHoverBrush => new SolidColorBrush(ForegroundHoverColor);

        private Color _foregroundPressedColor;
        public Color ForegroundPressedColor
        {
            get { return _foregroundPressedColor; }
            set
            {
                _foregroundPressedColor = value;
                OnPropertyChanged(nameof(ForegroundPressedColor));
                OnPropertyChanged(nameof(ForegroundPressedBrush));
            }
        }
        public SolidColorBrush ForegroundPressedBrush => new SolidColorBrush(ForegroundPressedColor);

        private Color _foregroundDisabledColor;
        public Color ForegroundDisabledColor
        {
            get { return _foregroundDisabledColor; }
            set
            {
                _foregroundDisabledColor = value;
                OnPropertyChanged(nameof(ForegroundDisabledColor));
                OnPropertyChanged(nameof(ForegroundBrush));
            }
        }
        public SolidColorBrush ForegroundDisabledBrush => new SolidColorBrush(ForegroundDisabledColor);
    }
}