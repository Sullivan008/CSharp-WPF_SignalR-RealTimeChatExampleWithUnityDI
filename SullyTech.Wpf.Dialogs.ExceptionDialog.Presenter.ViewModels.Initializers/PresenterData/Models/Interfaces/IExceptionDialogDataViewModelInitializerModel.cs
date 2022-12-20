using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

internal interface IExceptionDialogDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public string Message { get; init; }

    public Type Type { get; init; }

    public string? StackTrace { get; init; }

    public Exception? InnerException { get; init; }
}