using System.Windows.Input;
using WPFMVVMTemplate.MVVM.Commands;
using WPFMVVMTemplate.MVVM.Views;
using WPFMVVMTemplate.Themes;

namespace WPFMVVMTemplate.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly AppManager _app;

        public ViewModelBase CurrentViewModel => _app.NavigationStore.CurrentViewModel;

        public ICommand MainWindowCloseCommand { get; }
        public ICommand MainWindowMaximizeCommand { get; }
        public ICommand MainWindowMinimizeCommand { get; }

        public ICommand HomeViewCommand { get; }
        public ICommand SettingsViewCommand { get; }

        public MainViewModel(AppManager app)
        {
            _app = app;
            _app.NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _app.ThemeChanged += ApplicationThemeChanged;

            MainWindowCloseCommand = new ApplicationCommand(app, ApplicationCommandType.Close);
            MainWindowMaximizeCommand = new ApplicationCommand(app, ApplicationCommandType.Maximize);
            MainWindowMinimizeCommand = new ApplicationCommand(app, ApplicationCommandType.Minimize);

            HomeViewCommand = new NavigateCommand(app, View.Home);
            SettingsViewCommand = new NavigateCommand(_app, View.Settings);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void ApplicationThemeChanged(object? sender, ThemeEventArgs e)
        {

        }
    }
}