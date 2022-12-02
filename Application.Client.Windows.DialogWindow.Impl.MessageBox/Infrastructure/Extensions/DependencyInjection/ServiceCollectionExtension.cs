using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindow;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.ViewModels.MessageBoxWindowSettings.Initializer.Models;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer.Models;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.Infrastructure.Extensions.DependencyInjection;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMessageBoxWindow(this IServiceCollection @this)
    {
        @this.AddDialogWindow<MessageBoxWindow>();
        @this.AddDialogWindowViewModel<MessageBoxWindowViewModel>();

        @this.AddCurrentDialogWindowService<MessageBoxWindow>();

        @this.AddDialogWindowSettingsViewModelInitializer<MessageBoxWindowSettingsViewModel, MessageBoxWindowSettingsViewModelInitializerModel>();

        @this.AddPresenterViewModelInitializer<MessageBoxViewModel, MessageBoxViewModelInitializerModel>();
        @this.AddPresenterDataViewModelInitializer<MessageBoxViewDataViewModel, MessageBoxViewDataViewModelInitializerModel>();

        @this.AddPresenterDataViewModel<MessageBoxViewDataViewModel>();
        @this.AddPresenterViewModel<MessageBoxViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) => 
                new MessageBoxViewModel((MessageBoxViewDataViewModel)contentPresenterViewDataViewModel, (ICurrentDialogWindowService)currentWindowService));

        return @this;
    }
}