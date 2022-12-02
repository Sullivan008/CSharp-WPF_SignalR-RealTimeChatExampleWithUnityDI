using SullyTech.Guard;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;

public class ExceptionDialogViewDataViewModel : PresenterDataViewModel
{
    private string? _message;
    public string Message
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_message, nameof(Exception));

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
            Guard.ThrowIfNullOrWhitespace(_type, nameof(Type));

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
            Guard.ThrowIfNullOrWhitespace(_stackTrace, nameof(StackTrace));

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
            Guard.ThrowIfNullOrWhitespace(_innerException, nameof(InnerException));

            return _innerException!;
        }

        set
        {
            _innerException = value;
            OnPropertyChanged();
        }
    }
}