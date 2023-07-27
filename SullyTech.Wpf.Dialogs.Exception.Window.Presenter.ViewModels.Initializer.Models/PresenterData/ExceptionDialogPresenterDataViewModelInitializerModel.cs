using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializer.Models.PresenterData;

public sealed class ExceptionDialogPresenterDataViewModelInitializerModel : PresenterDataViewModelInitializerModel, IExceptionDialogPresenterDataViewModelInitializerModel
{
    private readonly string? _message;
    public string Message
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_message, nameof(Exception));

            return _message!;
        }

        init => _message = value;
    }

    private readonly Type? _type;
    public Type Type
    {
        get
        {
            Guard.Guard.ThrowIfNull(_type, nameof(Type));

            return _type!;
        }

        init => _type = value;
    }

    public string? StackTrace { get; init; }

    public System.Exception? InnerException { get; init; }
}