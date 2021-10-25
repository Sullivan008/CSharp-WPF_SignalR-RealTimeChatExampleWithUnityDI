using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Common.ViewModels;

namespace Application.Client.Common.Commands
{
    public abstract class AsyncCommandBase<TCallerViewModel> : ICommand where TCallerViewModel : ViewModelBase
    {
        public virtual Predicate<object?>? CanExecute { get; }

        protected readonly TCallerViewModel CallerViewModel;

        private bool _isExecuting;

        protected AsyncCommandBase(TCallerViewModel callerViewModel)
        {
            CanExecute = default;
            CallerViewModel = callerViewModel ?? throw new ArgumentNullException(nameof(callerViewModel));
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object? parameter)
        {
            if (!_isExecuting && CanExecute == null)
            {
                return true;
            }

            return !_isExecuting && CanExecute!(parameter);
        }

        async void ICommand.Execute(object? parameter)
        {
            _isExecuting = true;

            try
            {
                await ExecuteAsync();
            }
            finally
            {
                _isExecuting = false;
            }
        }

        public abstract Task ExecuteAsync();
    }

    public abstract class AsyncCommandBase<TCallerViewModel, TCommandParameter> : ICommand where TCallerViewModel : ViewModelBase
    {
        public virtual Predicate<object?>? CanExecute { get; }

        protected readonly TCallerViewModel CallerViewModel;

        private bool _isExecuting;

        protected AsyncCommandBase(TCallerViewModel callerViewModel)
        {
            CanExecute = default;
            CallerViewModel = callerViewModel ?? throw new ArgumentNullException(nameof(callerViewModel));
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object? parameter)
        {
            if (!_isExecuting && CanExecute == null)
            {
                return true;
            }

            return !_isExecuting && CanExecute!(parameter);
        }

        async void ICommand.Execute(object? parameter)
        {
            _isExecuting = true;

            try
            {
                await ExecuteAsync((TCommandParameter) parameter!);
            }
            finally
            {
                _isExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(TCommandParameter parameter);
    }
}