using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.WindowSettings.SubInterfaces;

namespace SullyTech.Wpf.Controls.Window.Standard.ViewModels.WindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindowSettingsViewModel<TIStandardWindowSettingsViewModel, TStandardWindowSettingsViewModel>(this IServiceCollection @this)
        where TStandardWindowSettingsViewModel : TIStandardWindowSettingsViewModel
        where TIStandardWindowSettingsViewModel : IStandardWindowSettingsViewModel
    {
        @this.AddTransient(typeof(TIStandardWindowSettingsViewModel), typeof(TStandardWindowSettingsViewModel));
    }

    public static void AdStandardPageSettingsSubViewModel<TIStandardWindowSettingsSubViewModel, TStandardWindowSettingsSubViewModel>(this IServiceCollection @this)
        where TIStandardWindowSettingsSubViewModel : IStandardWindowSettingsSubViewModel
        where TStandardWindowSettingsSubViewModel : TIStandardWindowSettingsSubViewModel
    {
        @this.AddTransient(typeof(TIStandardWindowSettingsSubViewModel), typeof(TStandardWindowSettingsSubViewModel));
    }
}