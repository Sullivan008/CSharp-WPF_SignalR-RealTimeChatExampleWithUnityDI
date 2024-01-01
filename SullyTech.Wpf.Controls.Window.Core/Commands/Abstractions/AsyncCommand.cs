using System.Windows.Input;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Window;

namespace SullyTech.Wpf.Controls.Window.Core.Commands.Abstractions;

public abstract class AsyncCommand<TCallerWindowViewModel> : ICommand
    where TCallerWindowViewModel : WindowViewModel
{
    private bool _isExecuting;

    protected readonly TCallerWindowViewModel CallerViewModel;

    protected AsyncCommand(TCallerWindowViewModel callerViewModel)
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
        if (!_isExecuting && CanExecute is null)
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

public abstract class AsyncCommand<TCallerWindowViewModel, TCommandParameter> : ICommand
    where TCallerWindowViewModel : WindowViewModel
{
    protected readonly TCallerWindowViewModel CallerViewModel;

    private bool _isExecuting;

    protected AsyncCommand(TCallerWindowViewModel callerViewModel)
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
        if (!_isExecuting && CanExecute is null)
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