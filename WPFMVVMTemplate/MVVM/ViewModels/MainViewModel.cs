using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMTemplate.MVVM.Commands;

namespace WPFMVVMTemplate.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly AppManager _app;

        public ViewModelBase CurrentViewModel => _app.NavigationStore.CurrentViewModel;

        public ICommand MainWindowCloseCommand { get; }
        public ICommand MainWindowMaximizeCommand { get; }
        public ICommand MainWindowMinimizeCommand { get; }

        public MainViewModel(AppManager app)
        {
            _app = app;
            _app.NavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            MainWindowCloseCommand = new ApplicationCommand(app, ApplicationCommandType.Close);
            MainWindowMaximizeCommand = new ApplicationCommand(app, ApplicationCommandType.Maximize);
            MainWindowMinimizeCommand = new ApplicationCommand(app, ApplicationCommandType.Minimize);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}