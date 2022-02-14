using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog;

public class ExceptionDialogViewModel : ContentPresenterViewModel<ExceptionDialogViewDataViewModel>
{
    public ExceptionDialogViewModel(ICurrentWindowService currentWindowService) : base(currentWindowService)
    { }
}