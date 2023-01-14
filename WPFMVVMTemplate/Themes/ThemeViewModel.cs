using System.Windows.Media;
using WPFMVVMTemplate.MVVM.ViewModels;

namespace WPFMVVMTemplate.Themes
{
    public class ThemeViewModel : ViewModelBase
    {
        private string _schemaName = string.Empty;
        public string SchemaName
        {
            get { return _schemaName; }
            set
            {
                _schemaName = value;
                OnPropertyChanged(nameof(SchemaName));
            }
        }

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


        private Color _panelBackgroundColor;
        public Color PanelBackgroundColor
        {
            get { return _panelBackgroundColor; }
            set
            {
                _panelBackgroundColor = value;
                OnPropertyChanged(nameof(PanelBackgroundColor));
                OnPropertyChanged(nameof(PanelBackgroundBrush));
            }
        }
        public SolidColorBrush PanelBackgroundBrush => new SolidColorBrush(PanelBackgroundColor);

        private Color _panelBorderColor;
        public Color PanelBorderColor
        {
            get { return _panelBorderColor; }
            set
            {
                _panelBorderColor = value;
                OnPropertyChanged(nameof(PanelBorderColor));
                OnPropertyChanged(nameof(PanelBorderBrush));
            }
        }
        public SolidColorBrush PanelBorderBrush => new SolidColorBrush(PanelBorderColor);

        private Color _panelBorderHoverColor;
        public Color PanelBorderHoverColor
        {
            get { return _panelBorderHoverColor; }
            set
            {
                _panelBorderHoverColor = value;
                OnPropertyChanged(nameof(PanelBorderHoverColor));
                OnPropertyChanged(nameof(PanelBorderHoverBrush));
            }
        }
        public SolidColorBrush PanelBorderHoverBrush => new SolidColorBrush(PanelBorderHoverColor);

        private Color _panelBorderPressedColor;
        public Color PanelBorderPressedColor
        {
            get { return _panelBorderPressedColor; }
            set
            {
                _panelBorderPressedColor = value;
                OnPropertyChanged(nameof(PanelBorderPressedColor));
                OnPropertyChanged(nameof(PanelBorderPressedBrush));
            }
        }
        public SolidColorBrush PanelBorderPressedBrush => new SolidColorBrush(PanelBorderPressedColor);


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




        private Color _themeColor;
        public Color ThemeColor
        {
            get { return _themeColor; }
            set
            {
                _themeColor = value;
                OnPropertyChanged(nameof(ThemeColor));
                OnPropertyChanged(nameof(ThemeBrush));
            }
        }
        public SolidColorBrush ThemeBrush => new SolidColorBrush(ThemeColor);

        private Color _themeHoverColor;
        public Color ThemeHoverColor
        {
            get { return _themeHoverColor; }
            set
            {
                _themeHoverColor = value;
                OnPropertyChanged(nameof(ThemeHoverColor));
                OnPropertyChanged(nameof(ThemeHoverBrush));
            }
        }
        public SolidColorBrush ThemeHoverBrush => new SolidColorBrush(ThemeHoverColor);

        private Color _themePressedColor;
        public Color ThemePressedColor
        {
            get { return _themePressedColor; }
            set
            {
                _themePressedColor = value;
                OnPropertyChanged(nameof(ThemePressedColor));
                OnPropertyChanged(nameof(ThemePressedBrush));
            }
        }
        public SolidColorBrush ThemePressedBrush => new SolidColorBrush(ThemePressedColor);

        private Color _themeDisabledColor;
        public Color ThemeDisabledColor
        {
            get { return _themeDisabledColor; }
            set
            {
                _themeDisabledColor = value;
                OnPropertyChanged(nameof(ThemeDisabledColor));
                OnPropertyChanged(nameof(ThemeDisabledBrush));
            }
        }
        public SolidColorBrush ThemeDisabledBrush => new SolidColorBrush(ThemeDisabledColor);

        private Color _themeForegroundColor;
        public Color ThemeForegroundColor
        {
            get { return _themeForegroundColor; }
            set
            {
                _themeForegroundColor = value;
                OnPropertyChanged(nameof(ThemeForegroundColor));
                OnPropertyChanged(nameof(ThemeForegroundBrush));
            }
        }
        public SolidColorBrush ThemeForegroundBrush => new SolidColorBrush(ThemeForegroundColor);

        private Color _themeForegroundDisabledColor;
        public Color ThemeForegroundDisabledColor
        {
            get { return _themeForegroundDisabledColor; }
            set
            {
                _themeForegroundDisabledColor = value;
                OnPropertyChanged(nameof(ThemeForegroundDisabledColor));
                OnPropertyChanged(nameof(ThemeForegroundDisabledBrush));
            }
        }
        public SolidColorBrush ThemeForegroundDisabledBrush => new SolidColorBrush(ThemeForegroundDisabledColor);



        private Color _deleteColor;
        public Color DeleteColor
        {
            get { return _deleteColor; }
            set
            {
                _deleteColor = value;
                OnPropertyChanged(nameof(DeleteColor));
                OnPropertyChanged(nameof(DeleteBrush));
            }
        }
        public SolidColorBrush DeleteBrush => new SolidColorBrush(DeleteColor);

        private Color _deleteHoverColor;
        public Color DeleteHoverColor
        {
            get { return _deleteHoverColor; }
            set
            {
                _deleteHoverColor = value;
                OnPropertyChanged(nameof(DeleteHoverColor));
                OnPropertyChanged(nameof(DeleteHoverBrush));
            }
        }
        public SolidColorBrush DeleteHoverBrush => new SolidColorBrush(DeleteHoverColor);

        private Color _deletePressedColor;
        public Color DeletePressedColor
        {
            get { return _deletePressedColor; }
            set
            {
                _deletePressedColor = value;
                OnPropertyChanged(nameof(DeletePressedColor));
                OnPropertyChanged(nameof(DeletePressedBrush));
            }
        }
        public SolidColorBrush DeletePressedBrush => new SolidColorBrush(DeletePressedColor);

        private Color _deleteDisabledColor;
        public Color DeleteDisabledColor
        {
            get { return _deleteDisabledColor; }
            set
            {
                _deleteDisabledColor = value;
                OnPropertyChanged(nameof(DeleteDisabledColor));
                OnPropertyChanged(nameof(DeleteDisabledBrush));
            }
        }
        public SolidColorBrush DeleteDisabledBrush => new SolidColorBrush(DeleteDisabledColor);

        private Color _deleteForegroundColor;
        public Color DeleteForegroundColor
        {
            get { return _deleteForegroundColor; }
            set
            {
                _deleteForegroundColor = value;
                OnPropertyChanged(nameof(DeleteForegroundColor));
                OnPropertyChanged(nameof(DeleteForegroundBrush));
            }
        }
        public SolidColorBrush DeleteForegroundBrush => new SolidColorBrush(DeleteForegroundColor);

        private Color _deleteForegroundDisabledColor;
        public Color DeleteForegroundDisabledColor
        {
            get { return _deleteForegroundDisabledColor; }
            set
            {
                _deleteForegroundDisabledColor = value;
                OnPropertyChanged(nameof(DeleteForegroundDisabledColor));
                OnPropertyChanged(nameof(DeleteForegroundDisabledBrush));
            }
        }
        public SolidColorBrush DeleteForegroundDisabledBrush => new SolidColorBrush(DeleteForegroundDisabledColor);
    }
}