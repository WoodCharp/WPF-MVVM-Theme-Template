using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMTemplate.MVVM.ViewModels;
using WPFMVVMTemplate.Themes;

namespace WPFMVVMTemplate
{
    public partial class App : Application
    {
        private readonly AppManager _app;

        public App()
        {
            _app = new AppManager();

            var lang = _app.Settings.Language;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            //Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = dateFormat;
            //Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern = dateFormat;
            //Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern = dateFormat;
            //Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongTimePattern = dateFormat;
            //Thread.CurrentThread.CurrentCulture.DateTimeFormat.FullDateTimePattern = dateFormat;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _app.Theme = (ThemeViewModel)Current.FindResource("Theme");
            _app.SetTheme(DefThemes.Dark);

            _app.NavigationStore.CurrentViewModel = new SettingsViewModel(_app);

            MainWindow = new MainWindow() { DataContext = new MainViewModel(_app) };
            MainWindow.Show();
        }
    }
}