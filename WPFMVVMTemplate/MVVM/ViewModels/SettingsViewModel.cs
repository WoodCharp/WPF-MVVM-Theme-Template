using WPFMVVMTemplate.Themes;

namespace WPFMVVMTemplate.MVVM.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly AppManager _app;

        private bool _langEng = false;
        public bool LangEng
        {
            get { return _langEng; }
            set
            {
                _langEng = value;
                OnPropertyChanged(nameof(LangEng));

                if (value)
                {
                    _app.SettingsSetLanguage("en-US");
                }
            }
        }

        private bool _langFi = false;
        public bool LangFi
        {
            get { return _langFi; }
            set
            {
                _langFi = value;
                OnPropertyChanged(nameof(LangFi));

                if (value)
                {
                    _app.SettingsSetLanguage("fi-FI");
                }
            }
        }


        private bool _themeDark = false;
        public bool ThemeDark
        {
            get { return _themeDark; }
            set
            {
                _themeDark = value;
                OnPropertyChanged(nameof(ThemeDark));

                if (value)
                {
                    _app.SetTheme(DefThemes.Dark);
                    _app.SettingsSetTheme("Dark");
                }
            }
        }

        private bool _themeLight = false;
        public bool ThemeLight
        {
            get { return _themeLight; }
            set
            {
                _themeLight = value;
                OnPropertyChanged(nameof(ThemeLight));

                if (value)
                {
                    _app.SetTheme(DefThemes.Light);
                    _app.SettingsSetTheme("Light");
                }
            }
        }

        public SettingsViewModel(AppManager app)
        {
            _app = app;

            if(_app.Settings.Language == "en-US") _langEng = true;
            else _langFi = true;

            if (_app.Settings.Theme == "Dark") _themeDark = true;
            else _themeLight = true;
        }
    }
}