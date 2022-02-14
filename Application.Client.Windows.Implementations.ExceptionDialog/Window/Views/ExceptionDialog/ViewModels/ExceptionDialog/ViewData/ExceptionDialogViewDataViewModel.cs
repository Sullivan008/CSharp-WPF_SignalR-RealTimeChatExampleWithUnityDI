using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;

public class ExceptionDialogViewDataViewModel : ContentPresenterViewDataViewModel
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
            Guard.ThrowIfNullOrWhitespace(value, nameof(Exception));
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
            Guard.ThrowIfNullOrWhitespace(value, nameof(Type));
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
            Guard.ThrowIfNullOrWhitespace(value, nameof(StackTrace));
            _stackTrace = value;

            OnPropertyChanged();
        }
    }
}