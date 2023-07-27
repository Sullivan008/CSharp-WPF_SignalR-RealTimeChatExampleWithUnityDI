using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;

public interface IExceptionDialogPresenterDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public string Message { get; init; }

    public Type Type { get; init; }

    public string? StackTrace { get; init; }

    public System.Exception? InnerException { get; init; }
}