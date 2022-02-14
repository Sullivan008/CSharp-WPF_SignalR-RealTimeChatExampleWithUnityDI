using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Initializer.Models;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer.Models;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Initializer;

public class ExceptionDialogViewModelInitializer : IContentPresenterViewModelInitializer<ExceptionDialogViewModel, ExceptionDialogViewModelInitializerModel>
{
    private readonly IContentPresenterViewDataViewModelInitializer<ExceptionDialogViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel> _viewDataInitializer;

    public ExceptionDialogViewModelInitializer(IContentPresenterViewDataViewModelInitializer<ExceptionDialogViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel> viewDataInitializer)
    {
        _viewDataInitializer = viewDataInitializer;
    }

    public void Initialize(ExceptionDialogViewModel contentPresenterViewModel, ExceptionDialogViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        _viewDataInitializer.Initialize(contentPresenterViewModel.ViewData, contentPresenterViewModelInitializerModel.ViewDataInitializerModel);
    }
}