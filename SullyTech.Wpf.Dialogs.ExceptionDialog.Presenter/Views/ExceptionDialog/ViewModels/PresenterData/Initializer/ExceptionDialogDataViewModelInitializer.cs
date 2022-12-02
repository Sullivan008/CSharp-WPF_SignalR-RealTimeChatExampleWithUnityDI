using SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.PresenterData.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Presenter.Views.ExceptionDialog.ViewModels.PresenterData.Initializer;

internal sealed class ExceptionDialogDataViewModelInitializer : IPresenterDataViewModelInitializer<ExceptionDialogDataViewModel, ExceptionDialogDataViewModelInitializerModel>
{
    public void Initialize(ExceptionDialogDataViewModel presenterDataViewModel, ExceptionDialogDataViewModelInitializerModel presenterDataViewModelInitializerModel)
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