using System.Windows.Input;
using Application.Client.Windows.Core.ViewModels.Window.Interfaces;

namespace Application.Client.Windows.Core.Commands.Abstractions;

public abstract class AsyncWindowCommand<TCallerWindowViewModel> : ICommand 
    where TCallerWindowViewModel : IWindowViewModel
{
    public virtual Predicate<object?>? CanExecute { get; }

    protected readonly TCallerWindowViewModel CallerViewModel;

    private bool _isExecuting;

    protected AsyncWindowCommand(TCallerWindowViewModel callerViewModel)
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

public abstract class AsyncWindowCommand<TCallerWindowViewModel, TCommandParameter> : ICommand
    where TCallerWindowViewModel : IWindowViewModel
{
    public virtual Predicate<object?>? CanExecute { get; }

    protected readonly TCallerWindowViewModel CallerViewModel;

    private bool _isExecuting;

    protected AsyncWindowCommand(TCallerWindowViewModel callerViewModel)
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