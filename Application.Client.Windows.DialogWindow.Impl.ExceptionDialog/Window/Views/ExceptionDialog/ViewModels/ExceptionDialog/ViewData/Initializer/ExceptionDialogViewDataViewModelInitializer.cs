using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer.Models;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer;

public class ExceptionDialogViewDataViewModelInitializer : IPresenterDataViewModelInitializer<ExceptionDialogViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel>
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