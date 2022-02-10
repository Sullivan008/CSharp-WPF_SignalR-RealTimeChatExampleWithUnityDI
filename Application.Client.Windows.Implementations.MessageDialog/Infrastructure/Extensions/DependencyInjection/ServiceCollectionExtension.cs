using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Window.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.MessageDialog.Window;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindow;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindow.Initializer.Models;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindowSettings;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindowSettings.Initializer.Models;
using Application.Client.Windows.Implementations.MessageDialog.Window.Views.Content.ViewModels.Content;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.MessageDialog.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMessageDialog(this IServiceCollection @this)
    {
        @this.AddDialogWindow<MessageDialogWindow>();
        @this.AddDialogWindowViewModel<MessageDialogWindowViewModel>();

        @this.AddCurrentDialogWindowService<MessageDialogWindow>();

        @this.AddDialogWindowViewModelInitializer<MessageDialogWindowViewModel, MessageDialogWindowViewModelInitializerModel>();
        @this.AddDialogWindowSettingsViewModelInitializer<MessageDialogWindowSettingsViewModel, MessageDialogWindowSettingsViewModelInitializerModel>();

        @this.AddContentPresenterViewModelInitializers();
        @this.AddContentPresenterViewDataViewModelInitializers();

        @this.AddContentPresenterViewModelFactory<ContentViewModel>(serviceProvider =>
            currentWindowService => 
                new ContentViewModel((ICurrentDialogWindowService)currentWindowService));

        return @this;
    }
}