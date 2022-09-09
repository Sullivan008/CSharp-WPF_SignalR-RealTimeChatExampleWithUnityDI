using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Client.Core.Commands
{
    public class RelayCommandAsync : ICommand
    {
        private readonly Func<Task> _execute;

        private readonly Action<object> _executeParam;

        private readonly Predicate<object> _canExecute;

        private bool _isExecuting;

        public RelayCommandAsync(Func<Task> execute) : this(execute, null)
        { }

        public RelayCommandAsync(Action<object> executeParam)
        {
            _executeParam = executeParam;
        }

        public RelayCommandAsync(Func<Task> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (!_isExecuting && _canExecute == null)
            {
                return true;
            }

            return !_isExecuting && _canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            _isExecuting = true;

            try
            {
                if (_execute != null)
                {
                    await _execute();
                }
                else
                {
                    _executeParam(parameter);
                }
            }
            finally
            {
                _isExecuting = false;
            }
        }
    }

    public class RelayCommandAsync<TCommandParameter> : ICommand
    {
        private readonly Func<Task> _execute;

        private readonly Action<TCommandParameter> _executeParam;

        private readonly Predicate<TCommandParameter> _canExecute;

        private bool _isExecuting;

        public RelayCommandAsync(Func<Task> execute) : this(execute, null)
        { }

        public RelayCommandAsync(Action<TCommandParameter> executeParam)
        {
            _executeParam = executeParam;
        }

        public RelayCommandAsync(Func<Task> execute, Predicate<TCommandParameter> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (!_isExecuting && _canExecute == null)
            {
                return true;
            }

            return !_isExecuting && _canExecute((TCommandParameter)parameter);
        }

        public async void Execute(object parameter)
        {
            _isExecuting = true;

            try
            {
                if (_execute != null)
                {
                    await _execute();
                }
                else
                {
                    _executeParam((TCommandParameter)parameter);
                }
            }
            finally
            {
                _isExecuting = false;
            }
        }
    }
}
