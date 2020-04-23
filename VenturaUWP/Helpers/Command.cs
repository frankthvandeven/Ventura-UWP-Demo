using System;
using System.Windows.Input;

namespace Ventura
{
    public class Command : ICommand
    {
        //These delegates store methods to be called that contains the body of the Execute and CanExecue methods
        //for each particular instance of DelegateCommand.
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _Execute;

        //Two Constructors, for convenience and clean code - often you won't need CanExecute
        public Command(Action<object> execute, Func<object, bool> canExecute)
        {
            _canExecute = canExecute;
            _Execute = execute;
        }

        public Command(Action<object> execute) : this(execute, null)
        {
        }

        //CanExecute and Execute come from ICommand
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;

            _Execute(parameter);
        }

        /// <summary>
        /// Not a part of ICommand, but commonly added so you can trigger a manual refresh on the result of CanExecute.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}



