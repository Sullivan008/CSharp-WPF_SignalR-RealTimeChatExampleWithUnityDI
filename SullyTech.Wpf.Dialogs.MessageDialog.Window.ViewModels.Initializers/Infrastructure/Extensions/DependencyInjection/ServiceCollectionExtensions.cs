using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Initializers.DialogWindowSettings.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogWindowSettingsViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddDialogWindowSettingsViewModelInitializer<IMessageDialogWindowSettingsViewModel, IMessageDialogWindowSettingsViewModelInitializerModel,
            IDialogWindowSettingsViewModelInitializer<IMessageDialogWindowSettingsViewModel, IMessageDialogWindowSettingsViewModelInitializerModel>, MessageDialogWindowSettingsViewModelInitializer>();
    }
}