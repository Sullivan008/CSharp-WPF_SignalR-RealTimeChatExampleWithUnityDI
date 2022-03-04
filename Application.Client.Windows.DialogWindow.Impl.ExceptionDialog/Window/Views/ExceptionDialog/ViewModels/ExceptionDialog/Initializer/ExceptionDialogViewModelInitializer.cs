using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Initializer.Models;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer.Models;
using Microsoft.Extensions.Hosting;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.Initializer;

public class ExceptionDialogViewModelInitializer : IContentPresenterViewModelInitializer<ExceptionDialogViewModel, ExceptionDialogViewModelInitializerModel>
{
    private readonly IHostEnvironment _hostEnvironment;

    private readonly IContentPresenterViewDataViewModelInitializer<ExceptionDialogViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel> _viewDataInitializer;

    public ExceptionDialogViewModelInitializer(IHostEnvironment hostEnvironment,
        IContentPresenterViewDataViewModelInitializer<ExceptionDialogViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel> viewDataInitializer)
    {
        _hostEnvironment = hostEnvironment;
        _viewDataInitializer = viewDataInitializer;
    }

    public void Initialize(ExceptionDialogViewModel contentPresenterViewModel, ExceptionDialogViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        _viewDataInitializer.Initialize(contentPresenterViewModel.ViewData, contentPresenterViewModelInitializerModel.ViewDataInitializerModel);

        contentPresenterViewModel.IsDeveloperMode = _hostEnvironment.IsDevelopment();
    }
}