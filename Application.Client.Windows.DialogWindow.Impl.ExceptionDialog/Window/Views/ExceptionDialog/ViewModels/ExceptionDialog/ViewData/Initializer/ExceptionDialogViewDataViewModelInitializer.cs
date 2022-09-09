using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer.Models;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer;

public class ExceptionDialogViewDataViewModelInitializer : IContentPresenterViewDataViewModelInitializer<ExceptionDialogViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel>
{
    public void Initialize(ExceptionDialogViewDataViewModel contentPresenterViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel contentPresenterViewDataViewModelInitializerModel)
    {
        contentPresenterViewDataViewModel.Message = contentPresenterViewDataViewModelInitializerModel.Message;
        contentPresenterViewDataViewModel.Type = contentPresenterViewDataViewModelInitializerModel.Type.FullName!;
        contentPresenterViewDataViewModel.StackTrace = InitializeStackTrace(contentPresenterViewDataViewModelInitializerModel.StackTrace);
        contentPresenterViewDataViewModel.InnerException = InitializeInnerException(contentPresenterViewDataViewModelInitializerModel.InnerException);
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
        if (innerException == null)
        {
            return "-";
        }

        return innerException.ToString();
    }
}