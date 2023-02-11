using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindowSettingsViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddDialogWindowSettingsViewModelInitializer<IExceptionDialogWindowSettingsViewModel, IExceptionDialogWindowSettingsViewModelInitializerModel,
            IDialogWindowSettingsViewModelInitializer<IExceptionDialogWindowSettingsViewModel, IExceptionDialogWindowSettingsViewModelInitializerModel>, ExceptionDialogWindowSettingsViewModelInitializer>();
    }
}