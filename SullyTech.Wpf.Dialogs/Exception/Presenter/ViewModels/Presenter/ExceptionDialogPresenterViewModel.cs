using System.Windows.Input;
using Microsoft.Extensions.Hosting;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter.Commands;

namespace SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter;

public sealed class ExceptionDialogPresenterViewModel : PresenterViewModel
{
    private readonly IHostEnvironment _hostEnvironment;


    private readonly IDialogWindowService _dialogWindowService;

    public ExceptionDialogPresenterViewModel(IHostEnvironment hostEnvironment, IDialogWindowService dialogWindowService)
    {
        _hostEnvironment = hostEnvironment;
        _dialogWindowService = dialogWindowService;

        LoadedCommand = new LoadedCommand(this);
    }

    public bool IsDeveloperMode => _hostEnvironment.IsDevelopment();


    private string _message = string.Empty;
    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    private string _type = string.Empty;
    public string Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged();
        }
    }

    private string? _stackTrace;
    public string? StackTrace
    {
        get => _stackTrace;
        set
        {
            _stackTrace = value;
            OnPropertyChanged();
        }
    }

    private string? _innerException;
    public string? InnerException
    {
        get => _innerException;
        set
        {
            _innerException = value;
            OnPropertyChanged();
        }
    }


    private ICommand? _okCommand;
    public ICommand OkCommand =>
        _okCommand ??= new OkCommand(this, _dialogWindowService);
}