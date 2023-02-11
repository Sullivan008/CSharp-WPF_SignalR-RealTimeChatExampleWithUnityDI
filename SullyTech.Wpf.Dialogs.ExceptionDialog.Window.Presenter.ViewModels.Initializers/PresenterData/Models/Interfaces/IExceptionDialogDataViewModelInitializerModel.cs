using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

public interface IExceptionDialogDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public string Message { get; init; }

    public Type Type { get; init; }

    public string? StackTrace { get; init; }

    public Exception? InnerException { get; init; }
}