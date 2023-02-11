using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.PresenterData;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.PresenterData;

public sealed class ExceptionDialogDataViewModel : PresenterDataViewModel, IExceptionDialogDataViewModel
{
    private string? _message;
    public string Message
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_message, nameof(Exception));

            return _message!;
        }

        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    private string? _type;
    public string Type
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_type, nameof(Type));

            return _type!;
        }

        set
        {
            _type = value;
            OnPropertyChanged();
        }
    }

    private string? _stackTrace;
    public string StackTrace
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_stackTrace, nameof(StackTrace));

            return _stackTrace!;
        }

        set
        {
            _stackTrace = value;
            OnPropertyChanged();
        }
    }

    private string? _innerException;
    public string InnerException
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_innerException, nameof(InnerException));

            return _innerException!;
        }

        set
        {
            _innerException = value;
            OnPropertyChanged();
        }
    }
}