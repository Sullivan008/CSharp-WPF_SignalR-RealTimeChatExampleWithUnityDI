using System.Windows.Input;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;

public abstract class AsyncCommand<TCallerPresenterViewModel> : ICommand
    where TCallerPresenterViewModel : IPresenterViewModel
{
    private bool _isExecuting;
    
    protected readonly TCallerPresenterViewModel CallerViewModel;
    
    protected AsyncCommand(TCallerPresenterViewModel callerViewModel)
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

public abstract class AsyncCommand<TCallerPresenterViewModel, TCommandParameter> : ICommand
    where TCallerPresenterViewModel : IPresenterViewModel
{
    private bool _isExecuting;

    protected readonly TCallerPresenterViewModel CallerViewModel;

    protected AsyncCommand(TCallerPresenterViewModel callerViewModel)
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