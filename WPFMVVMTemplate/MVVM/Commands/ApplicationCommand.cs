namespace WPFMVVMTemplate.MVVM.Commands
{
    public class ApplicationCommand : CommandBase
    {
        private AppManager _app;
        private ApplicationCommandType _commandType;

        public ApplicationCommand(AppManager app, ApplicationCommandType commandType)
        {
            _app = app;
            _commandType = commandType;
        }

        public override void Execute(object? parameter) { _app.WindowCommand(_commandType); }
    }
}