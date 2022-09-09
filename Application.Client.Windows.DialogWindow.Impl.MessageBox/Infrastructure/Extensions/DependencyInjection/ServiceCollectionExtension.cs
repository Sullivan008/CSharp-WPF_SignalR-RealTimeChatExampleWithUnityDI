using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Core.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Core.Window.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow.Initializer.Models;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings.Initializer.Models;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMessageBoxWindow(this IServiceCollection @this)
    {
        @this.AddDialogWindow<MessageBoxWindow>();
        @this.AddDialogWindowViewModel<MessageBoxWindowViewModel>();

        @this.AddCurrentDialogWindowService<MessageBoxWindow>();

        @this.AddDialogWindowViewModelInitializer<MessageBoxWindowViewModel, MessageBoxWindowViewModelInitializerModel>();
        @this.AddDialogWindowSettingsViewModelInitializer<MessageBoxWindowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel>();

        @this.AddContentPresenterViewModelInitializers();
        @this.AddContentPresenterViewDataViewModelInitializers();

        @this.AddContentPresenterViewDataViewModel<MessageBoxViewDataViewModel>();
        @this.AddContentPresenterViewModelFactory<MessageBoxViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) => 
                new MessageBoxViewModel((MessageBoxViewDataViewModel)contentPresenterViewDataViewModel, (ICurrentDialogWindowService)currentWindowService));

        return @this;
    }
}