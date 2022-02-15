using System.Windows.Input;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;

public abstract class AsyncContentPresenterCommand<TCallerContentPresenterViewModel> : ICommand 
    where TCallerContentPresenterViewModel : IContentPresenterViewModel
{
    public virtual Predicate<object?>? CanExecute { get; }

    protected readonly TCallerContentPresenterViewModel CallerViewModel;

    private bool _isExecuting;

    protected AsyncContentPresenterCommand(TCallerContentPresenterViewModel callerViewModel)
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

public abstract class AsyncContentPresenterCommand<TCallerContentPresenterViewModel, TCommandParameter> : ICommand
    where TCallerContentPresenterViewModel : IContentPresenterViewModel
{
    public virtual Predicate<object?>? CanExecute { get; }

    protected readonly TCallerContentPresenterViewModel CallerViewModel;

    private bool _isExecuting;

    protected AsyncContentPresenterCommand(TCallerContentPresenterViewModel callerViewModel)
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