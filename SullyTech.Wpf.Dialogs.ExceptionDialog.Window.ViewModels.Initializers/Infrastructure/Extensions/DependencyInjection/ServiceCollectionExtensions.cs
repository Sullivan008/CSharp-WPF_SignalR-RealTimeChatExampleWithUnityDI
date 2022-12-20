using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindowViewModelInitializer(this IServiceCollection @this)
    { }

    public static void AddExceptionDialogWindowSettingsViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddDialogWindowSettingsViewModelInitializer<IExceptionDialogWindowSettingsViewModel, IExceptionDialogWindowSettingsViewModelInitializerModel>();
    }
}