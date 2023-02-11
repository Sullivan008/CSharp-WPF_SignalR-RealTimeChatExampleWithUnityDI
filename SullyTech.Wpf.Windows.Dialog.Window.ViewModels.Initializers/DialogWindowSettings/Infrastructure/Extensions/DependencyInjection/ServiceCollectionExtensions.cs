using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Initializers.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowSettingsViewModelInitializer<TIDialogWindowSettingsViewModel, TIDialogWindowSettingsViewModelInitializerModel,
        TIDialogWindowSettingsViewModelInitializer, TDialogWindowSettingsViewModelInitializer>(this IServiceCollection @this)
            where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
            where TIDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
            where TIDialogWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<TIDialogWindowSettingsViewModel, TIDialogWindowSettingsViewModelInitializerModel>
            where TDialogWindowSettingsViewModelInitializer : TIDialogWindowSettingsViewModelInitializer

    {
        @this.AddScoped(typeof(TIDialogWindowSettingsViewModelInitializer), typeof(TDialogWindowSettingsViewModelInitializer));
    }
}