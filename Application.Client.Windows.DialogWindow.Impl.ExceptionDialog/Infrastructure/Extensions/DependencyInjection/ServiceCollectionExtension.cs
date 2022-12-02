using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings.Initializer.Models;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData;
using Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window.Views.ExceptionDialog.ViewModels.ExceptionDialog.ViewData.Initializer.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Infrastructure.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddExceptionDialogWindow(this IServiceCollection @this)
    {
        @this.AddDialogWindow<ExceptionDialogWindow>();
        @this.AddDialogWindowViewModel<ExceptionDialogWindowViewModel>();

        @this.AddCurrentDialogWindowService<ExceptionDialogWindow>();

        @this.AddDialogWindowSettingsViewModelInitializer<ExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModelInitializerModel>();

        @this.AddPresenterDataViewModelInitializer<ExceptionDialogViewDataViewModel, ExceptionDialogViewDataViewModelInitializerModel>();

        @this.AddPresenterDataViewModel<ExceptionDialogViewDataViewModel>();
        @this.AddPresenterViewModel<ExceptionDialogViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) =>
                new ExceptionDialogViewModel((ExceptionDialogViewDataViewModel)contentPresenterViewDataViewModel, serviceProvider.GetRequiredService<IHostEnvironment>(),
                    (ICurrentDialogWindowService)currentWindowService));

        return @this;
    }
}