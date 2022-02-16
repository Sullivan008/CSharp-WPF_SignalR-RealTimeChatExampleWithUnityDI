using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Window.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.ExceptionDialog.Window;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Initializer.Models;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings.Initializer.Models;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddExceptionDialogWindow(this IServiceCollection @this)
    {
        @this.AddDialogWindow<ExceptionDialogWindow>();
        @this.AddDialogWindowViewModel<ExceptionDialogWindowViewModel>();

        @this.AddCurrentDialogWindowService<ExceptionDialogWindow>();

        @this.AddDialogWindowViewModelInitializer<ExceptionDialogWindowViewModel, ExceptionDialogWindowViewModelInitializerModel>();
        @this.AddDialogWindowSettingsViewModelInitializer<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel>();

        @this.AddContentPresenterViewModelInitializers();
        @this.AddContentPresenterViewDataViewModelInitializers();

        @this.AddContentPresenterViewDataViewModel<ExceptionDialogViewDataViewModel>();
        @this.AddContentPresenterViewModelFactory<ExceptionDialogViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) =>
                new ExceptionDialogViewModel((ExceptionDialogViewDataViewModel)contentPresenterViewDataViewModel, (ICurrentDialogWindowService)currentWindowService));

        return @this;
    }
}