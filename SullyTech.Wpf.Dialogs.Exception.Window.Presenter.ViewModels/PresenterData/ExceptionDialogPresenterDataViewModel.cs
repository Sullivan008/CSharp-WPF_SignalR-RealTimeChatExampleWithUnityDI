using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.PresenterData;

public sealed class ExceptionDialogPresenterDataViewModel : PresenterDataViewModel, IExceptionDialogPresenterDataViewModel
{
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

    private string _stackTrace = string.Empty;
    public string StackTrace
    {
        get => _stackTrace;
        set
        {
            _stackTrace = value;
            OnPropertyChanged();
        }
    }

    private string _innerException = string.Empty;
    public string InnerException
    {
        get => _innerException;
        set
        {
            _innerException = value;
            OnPropertyChanged();
        }
    }
}