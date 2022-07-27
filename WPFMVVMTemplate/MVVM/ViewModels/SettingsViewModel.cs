using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WPFMVVMTemplate.MVVM.Commands;
using WPFMVVMTemplate.Themes;

namespace WPFMVVMTemplate.MVVM.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly AppManager _app;

        public ICommand DarkCommand { get; }
        public ICommand LightCommand { get; }
        public ICommand enCommand { get; }
        public ICommand fiCommand { get; }

        public SettingsViewModel(AppManager app)
        {
            _app = app;
            DarkCommand = new ActionCommand(Dark);
            LightCommand = new ActionCommand(Light);
            enCommand = new ActionCommand(LangEn);
            fiCommand = new ActionCommand(LangFi);
        }

        private void LangFi()
        {
            Properties.Settings.Default.Language = "fi-FI";
            Properties.Settings.Default.Save();
        }

        private void LangEn()
        {
            Properties.Settings.Default.Language = "en-US";
            Properties.Settings.Default.Save();
        }

        private void Light()
        {
            _app.SetTheme(DefThemes.Light);
        }

        private void Dark()
        {
            _app.SetTheme(DefThemes.Dark);
        }
    }
}