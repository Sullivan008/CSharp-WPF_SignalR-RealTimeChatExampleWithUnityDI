using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Window.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.MessageDialog.Window;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindow;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindow.Initializer.Models;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindowSettings;
using Application.Client.Windows.Implementations.MessageDialog.Window.ViewModels.MessageDialogWindowSettings.Initializer.Models;
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
        
        return @this;
    }
}