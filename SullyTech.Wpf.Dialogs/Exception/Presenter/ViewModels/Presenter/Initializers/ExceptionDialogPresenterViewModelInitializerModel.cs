using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Initializers.Models;

namespace SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter.Initializers;

public record ExceptionDialogPresenterViewModelInitializerModel : PresenterViewModelInitializerModel
{
    public required string Message { get; init; }

    public required Type Type { get; init; }

    public string? StackTrace { get; init; }

    public System.Exception? InnerException { get; init; }
}