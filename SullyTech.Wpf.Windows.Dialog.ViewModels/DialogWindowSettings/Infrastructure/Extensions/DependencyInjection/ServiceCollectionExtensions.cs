using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindowSettings;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowSettingsViewModel<TDialogWindowSettingsViewModel>(this IServiceCollection @this)
        where TDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
    {
        @this.AddTransient(typeof(TDialogWindowSettingsViewModel));
    }
}