using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Initializers.PresenterData;

internal sealed class ExceptionDialogPresenterDataViewModelInitializer : IPresenterDataViewModelInitializer<IExceptionDialogPresenterDataViewModel, IExceptionDialogPresenterDataViewModelInitializerModel>
{
    public void Initialize(IExceptionDialogPresenterDataViewModel presenterDataViewModel, IExceptionDialogPresenterDataViewModelInitializerModel presenterDataViewModelInitializerModel)
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

    private static string InitializeInnerException(System.Exception? innerException)
    {
        if (innerException is null)
        {
            return "-";
        }

        return innerException.ToString();
    }
}