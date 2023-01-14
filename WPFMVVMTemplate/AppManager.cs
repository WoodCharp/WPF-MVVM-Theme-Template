using System;
using System.Windows;
using WPFMVVMTemplate.MVVM.Commands;
using WPFMVVMTemplate.MVVM.Stores;
using WPFMVVMTemplate.MVVM.ViewModels;
using WPFMVVMTemplate.MVVM.Views;
using WPFMVVMTemplate.Notifications;
using WPFMVVMTemplate.Themes;
using WPFMVVMTemplate.Properties.Languages;

namespace WPFMVVMTemplate
{
    public class AppManager
    {
        public ApplicationSettings Settings { get; private set; }

        public AppManager()
        {
            NavigationStore = new NavigationStore();
            Theme = new ThemeViewModel();

            Settings = new ApplicationSettings(Properties.Settings.Default.Theme, Properties.Settings.Default.Language);
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

        public EventHandler<ThemeEventArgs>? ThemeChanged { get; set; }
        protected virtual void OnThemeChanged(ThemeEventArgs args) { ThemeChanged?.Invoke(this, args); }

        public void SetTheme(ColorSchema cs)
        {
            Theme.SchemaName = cs.SchemaName;

            Theme.WindowTitleBarColor = cs.WindowTitleBarColor;
            Theme.WindowBackgroundColor = cs.WindowBackgroundColor;

            Theme.PanelBackgroundColor = cs.PanelBackgroundColor;
            Theme.PanelBorderColor = cs.PanelBorderColor;
            Theme.PanelBorderHoverColor = cs.PanelBorderHoverColor;
            Theme.PanelBorderPressedColor = cs.PanelBorderPressedColor;

            Theme.ForegroundColor = cs.ForegroundColor;
            Theme.ForegroundHoverColor = cs.ForegroundHoverColor;
            Theme.ForegroundPressedColor = cs.ForegroundPressedColor;
            Theme.ForegroundDisabledColor = cs.ForegroundDisabledColor;

            Theme.ThemeColor = cs.ThemeColor;
            Theme.ThemeHoverColor = cs.ThemeHoverColor;
            Theme.ThemePressedColor = cs.ThemePressedColor;
            Theme.ThemeDisabledColor = cs.ThemeDisabledColor;
            Theme.ThemeForegroundColor = cs.ThemeForegroundColor;
            Theme.ThemeForegroundDisabledColor = cs.ThemeForegroundDisabledColor;

            Theme.DeleteColor = cs.DeleteColor;
            Theme.DeleteHoverColor = cs.DeleteHoverColor;
            Theme.DeletePressedColor = cs.DeletePressedColor;
            Theme.DeleteDisabledColor = cs.DeleteDisabledColor;
            Theme.DeleteForegroundColor = cs.DeleteForegroundColor;
            Theme.DeleteForegroundDisabledColor = cs.DeleteForegroundDisabledColor;

            OnThemeChanged(new ThemeEventArgs(cs));
        }

        #endregion

        #region Navigation

        public NavigationStore NavigationStore { get; }

        public void Navigate(View view)
        {
            switch(view)
            {
                case View.Home: NavigationStore.CurrentViewModel = new HomeViewModel(this); break;
                case View.Settings: NavigationStore.CurrentViewModel = new SettingsViewModel(this); break;
            }
        }

        #endregion

        #region Settings

        public void SettingsSetTheme(string theme)
        {
            Settings.Theme = theme;
            Properties.Settings.Default.Theme = theme;
            Properties.Settings.Default.Save();
        }

        public async void SettingsSetLanguage(string lang)
        {
            Settings.Language = lang;
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();

            await Notification.ShowMessage(Lang.language, Lang.restartText,
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion
    }
}

public class ApplicationSettings
{
    public string Theme { get; set; }
    public string Language { get; set; }

    public ApplicationSettings(string theme, string language)
    {
        Theme = theme;
        Language = language;
    }
}