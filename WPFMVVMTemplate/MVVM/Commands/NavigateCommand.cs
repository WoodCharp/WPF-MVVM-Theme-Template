using WPFMVVMTemplate.MVVM.Views;

namespace WPFMVVMTemplate.MVVM.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly AppManager _app;
        private readonly View _view;

        public NavigateCommand(AppManager app, View view)
        {
            _app = app;
            _view = view;
        }

        public override void Execute(object? parameter) { _app.Navigate(_view); }
    }
}