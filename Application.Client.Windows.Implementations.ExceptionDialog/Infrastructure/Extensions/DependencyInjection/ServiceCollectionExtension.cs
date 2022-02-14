using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.DialogWindow.Window.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.ExceptionDialog.Window;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindow.Initializer.Models;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings;
using Application.Client.Windows.Implementations.ExceptionDialog.Window.ViewModels.ExceptionDialogWindowSettings.Initializer.Models;
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

        return @this;
    }
}