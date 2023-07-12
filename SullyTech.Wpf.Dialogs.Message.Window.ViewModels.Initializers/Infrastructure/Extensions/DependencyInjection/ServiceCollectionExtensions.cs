using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializers.WindowSettings;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMessageDialogWindowSettingsViewModelInitializer(this IServiceCollection @this)
    {
        @this.AddDialogWindowSettingsViewModelInitializer<
            IMessageDialogWindowSettingsViewModel,
            IMessageDialogWindowSettingsViewModelInitializerModel,
            IDialogWindowSettingsViewModelInitializer<IMessageDialogWindowSettingsViewModel, IMessageDialogWindowSettingsViewModelInitializerModel>,
            MessageDialogWindowSettingsViewModelInitializer>();
    }
}