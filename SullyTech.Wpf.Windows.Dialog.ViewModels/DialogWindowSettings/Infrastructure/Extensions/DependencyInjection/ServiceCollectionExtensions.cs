using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowSettingsViewModel<TIDialogWindowSettingsViewModel, TDialogWindowSettingsViewModel>(this IServiceCollection @this)
        where TDialogWindowSettingsViewModel : TIDialogWindowSettingsViewModel
        where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
    {
        @this.AddTransient(typeof(TIDialogWindowSettingsViewModel), typeof(TDialogWindowSettingsViewModel));
    }
}