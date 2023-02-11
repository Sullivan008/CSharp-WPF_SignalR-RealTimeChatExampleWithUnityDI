using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models;

public sealed class ExceptionDialogDataViewModelInitializerModel : IExceptionDialogDataViewModelInitializerModel
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

    public Exception? InnerException { get; init; }
}