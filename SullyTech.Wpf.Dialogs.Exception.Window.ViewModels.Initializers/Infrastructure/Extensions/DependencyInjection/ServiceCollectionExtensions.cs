using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.WindowSettings;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionDialogWindowSettingsViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddDialogWindowSettingsViewModelInitializer<
            IExceptionDialogWindowSettingsViewModel,
            IExceptionDialogWindowSettingsViewModelInitializerModel,
            IDialogWindowSettingsViewModelInitializer<IExceptionDialogWindowSettingsViewModel, IExceptionDialogWindowSettingsViewModelInitializerModel>,
            ExceptionDialogWindowSettingsViewModelInitializer>();
    }
}