using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer.Models;

public class ExceptionDialogViewDataViewModelInitializerModel : ContentPresenterViewDataViewModelInitializerModel
{
    private readonly string? _message;
    public string Message
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_message, nameof(Exception));

            return _message!;
        }

        init
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Exception));

            _message = value;
        }
    }

    private readonly Type? _type;
    public Type Type
    {
        get
        {
            Guard.ThrowIfNull(_type, nameof(Type));

            return _type!;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(Type));

            _type = value;
        }
    }

    public string? StackTrace { get; init; }
    public Exception? InnerException { get; init; }
}