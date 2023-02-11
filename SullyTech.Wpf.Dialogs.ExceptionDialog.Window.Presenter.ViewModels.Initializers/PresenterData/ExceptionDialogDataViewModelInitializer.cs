using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Presenter.ViewModels.Initializers.PresenterData;

internal sealed class ExceptionDialogDataViewModelInitializer : IPresenterDataViewModelInitializer<IExceptionDialogDataViewModel, IExceptionDialogDataViewModelInitializerModel>
{
    public void Initialize(IExceptionDialogDataViewModel presenterDataViewModel, IExceptionDialogDataViewModelInitializerModel presenterDataViewModelInitializerModel)
    {
        presenterDataViewModel.Message = presenterDataViewModelInitializerModel.Message;
        presenterDataViewModel.Type = presenterDataViewModelInitializerModel.Type.FullName!;
        presenterDataViewModel.StackTrace = InitializeStackTrace(presenterDataViewModelInitializerModel.StackTrace);
        presenterDataViewModel.InnerException = InitializeInnerException(presenterDataViewModelInitializerModel.InnerException);
    }

    private static string InitializeStackTrace(string? stackTrace)
    {
        if (string.IsNullOrWhiteSpace(stackTrace))
        {
            return "-";
        }

        return stackTrace;
    }

    private static string InitializeInnerException(Exception? innerException)
    {
        if (innerException is null)
        {
            return "-";
        }

        return innerException.ToString();
    }
}