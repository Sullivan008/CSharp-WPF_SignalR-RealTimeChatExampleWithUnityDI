using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.PresenterData;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializer.Models.PresenterData;

public sealed class ExceptionDialogPresenterDataViewModelInitializerModel : PresenterDataViewModelInitializerModel, IExceptionDialogPresenterDataViewModelInitializerModel
{
    public required string Message { get; init; }

    public required Type Type { get; init; }

    public string? StackTrace { get; init; }

    public System.Exception? InnerException { get; init; }
}