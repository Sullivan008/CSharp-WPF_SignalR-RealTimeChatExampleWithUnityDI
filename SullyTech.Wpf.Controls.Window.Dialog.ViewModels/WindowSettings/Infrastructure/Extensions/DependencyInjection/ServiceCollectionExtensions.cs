using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.WindowSettings.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.WindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDialogWindowSettingsViewModel<TIDialogWindowSettingsViewModel, TDialogWindowSettingsViewModel>(this IServiceCollection @this)
        where TDialogWindowSettingsViewModel : TIDialogWindowSettingsViewModel
        where TIDialogWindowSettingsViewModel : IDialogWindowSettingsViewModel
    {
        @this.AddTransient(typeof(TIDialogWindowSettingsViewModel), typeof(TDialogWindowSettingsViewModel));
    }

    public static void AddDialogWindowSettingsSubViewModel<TIDialogWindowSettingsSubViewModel, TDialogWindowSettingsSubViewModel>(this IServiceCollection @this)
        where TDialogWindowSettingsSubViewModel : TIDialogWindowSettingsSubViewModel
        where TIDialogWindowSettingsSubViewModel : IDialogWindowSettingsSubViewModel
    {
        @this.AddTransient(typeof(TIDialogWindowSettingsSubViewModel), typeof(TDialogWindowSettingsSubViewModel));
    }
}