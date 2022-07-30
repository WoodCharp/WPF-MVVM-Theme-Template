using System.Windows;
using WPFMVVMTemplate.MVVM.Commands;
using WPFMVVMTemplate.MVVM.Stores;
using WPFMVVMTemplate.MVVM.ViewModels;
using WPFMVVMTemplate.MVVM.Views;
using WPFMVVMTemplate.Themes;

namespace WPFMVVMTemplate
{
    public class AppManager
    {
        public ApplicationSettings Settings { get; private set; }

        public AppManager()
        {
            NavigationStore = new NavigationStore();
            Theme = new ThemeViewModel();

            Settings = new ApplicationSettings(Properties.Settings.Default.Language);
        }

        #region Main window

        public void WindowCommand(ApplicationCommandType mwct)
        {
            switch(mwct)
            {
                case ApplicationCommandType.Close: ApplicationClose(); break;
                case ApplicationCommandType.Maximize: ApplicationMaximize(); break;
                case ApplicationCommandType.Minimize: ApplicationMinimize(); break;
                case ApplicationCommandType.Restart: ApplicationRestart(); break;
            }
        }

        private void ApplicationMaximize()
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;
        }

        private void ApplicationMinimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ApplicationClose()
        {
            Application.Current.Shutdown();
        }

        private void ApplicationRestart()
        {
            //Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        #endregion

        #region Theme

        public ThemeViewModel Theme { get; set; }

        public void SetTheme(ColorSchema cs)
        {
            Theme.WindowTitleBarColor = cs.WindowTitleBarColor;
            Theme.WindowBackgroundColor = cs.WindowBackgroundColor;

            Theme.ForegroundColor = cs.ForegroundColor;
            Theme.ForegroundHoverColor = cs.ForegroundHoverColor;
            Theme.ForegroundPressedColor = cs.ForegroundPressedColor;
            Theme.ForegroundDisabledColor = cs.ForegroundDisabledColor;
        }

        #endregion


        #region Navigation

        public NavigationStore NavigationStore { get; }

        public void Navigate(View view)
        {
            switch(view)
            {
                case View.Settings: NavigationStore.CurrentViewModel = new SettingsViewModel(this); break;
            }
        }

        #endregion
    }
}

public class ApplicationSettings
{
    public string Language { get; set; }

    public ApplicationSettings(string language)
    {
        Language = language;
    }
}