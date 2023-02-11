using System.Windows.Input;
using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Windows.Core.Window.ViewModels.Commands.Abstractions;

public abstract class AsyncCommand<TICallerWindowViewModel> : ICommand
    where TICallerWindowViewModel : IWindowViewModel
{
    private bool _isExecuting;

    protected readonly TICallerWindowViewModel CallerViewModel;

    protected AsyncCommand(TICallerWindowViewModel callerViewModel)
    {
        Guard.Guard.ThrowIfNull(callerViewModel, nameof(callerViewModel));
        CallerViewModel = callerViewModel;
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

    public virtual Predicate<object?>? CanExecute => default;
}

public abstract class AsyncCommand<TICallerWindowViewModel, TCommandParameter> : ICommand
    where TICallerWindowViewModel : IWindowViewModel
{
    protected readonly TICallerWindowViewModel CallerViewModel;

    private bool _isExecuting;

    protected AsyncCommand(TICallerWindowViewModel callerViewModel)
    {
        Guard.Guard.ThrowIfNull(callerViewModel, nameof(callerViewModel));
        CallerViewModel = callerViewModel;
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
            await ExecuteAsync((TCommandParameter)parameter!);
        }
        finally
        {
            _isExecuting = false;
        }
    }

    public virtual Predicate<object?>? CanExecute => default;

    public abstract Task ExecuteAsync(TCommandParameter parameter);
}