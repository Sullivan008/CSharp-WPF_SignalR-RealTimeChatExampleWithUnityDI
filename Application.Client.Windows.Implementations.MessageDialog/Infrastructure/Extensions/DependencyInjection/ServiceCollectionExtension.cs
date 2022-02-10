using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Window.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.MessageBox.Window;
using Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindow;
using Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindow.Initializer.Models;
using Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindowSettings;
using Application.Client.Windows.Implementations.MessageBox.Window.ViewModels.MessageBoxWindowSettings.Initializer.Models;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.MessageBox.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMessageBox(this IServiceCollection @this)
    {
        @this.AddDialogWindow<MessageBoxWindow>();
        @this.AddDialogWindowViewModel<MessageBoxWindowViewModel>();

        @this.AddCurrentDialogWindowService<MessageBoxWindow>();

        @this.AddDialogWindowViewModelInitializer<MessageBoxWindowViewModel, MessageBoxWindowViewModelInitializerModel>();
        @this.AddDialogWindowSettingsViewModelInitializer<MessageBoxWindowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel>();

        @this.AddContentPresenterViewModelInitializers();
        @this.AddContentPresenterViewDataViewModelInitializers();

        @this.AddContentPresenterViewModelFactory<MessageBoxViewModel>(serviceProvider =>
            currentWindowService => 
                new MessageBoxViewModel((ICurrentDialogWindowService)currentWindowService));

        return @this;
    }
}