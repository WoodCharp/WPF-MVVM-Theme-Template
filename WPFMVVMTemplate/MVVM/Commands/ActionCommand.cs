using System;

namespace WPFMVVMTemplate.MVVM.Commands
{
    public class ActionCommand : CommandBase
    {
        public event Action? Click;

        public ActionCommand(Action click) { Click = click; }

        public override void Execute(object? parameter) { Click?.Invoke(); }
    }
}