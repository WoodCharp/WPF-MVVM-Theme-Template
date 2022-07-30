using System;
using System.Windows.Input;

namespace WPFMVVMTemplate.MVVM.Commands
{
    public class ObjectCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Action<object?> _handler;

        public ObjectCommand(Action<object?> handler) { _handler = handler; }

        public bool CanExecute(object? parameter) { return true; }

        public void Execute(object? parameter) { _handler(parameter); }
    }
}