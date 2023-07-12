using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Window.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.WindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindowViewModel(this IServiceCollection @this)
    {
        @this.AddDialogWindowViewModel<IExceptionDialogWindowViewModel, ExceptionDialogWindowViewModel>();
    }

    public static void AddExceptionDialogWindowSettingsViewModel(this IServiceCollection @this)
    {
        @this.AddDialogWindowSettingsViewModel<IExceptionDialogWindowSettingsViewModel, ExceptionDialogWindowSettingsViewModel>();
    }
}