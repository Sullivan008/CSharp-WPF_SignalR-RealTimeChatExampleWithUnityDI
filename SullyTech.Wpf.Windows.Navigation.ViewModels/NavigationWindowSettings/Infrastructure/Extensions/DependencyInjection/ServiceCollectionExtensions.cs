using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindowSettings;

namespace SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindowSettingsViewModel<TINavigationWindowSettingsViewModel, TNavigationWindowSettingsViewModel>(this IServiceCollection @this)
        where TNavigationWindowSettingsViewModel : TINavigationWindowSettingsViewModel
        where TINavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
    {
        @this.AddTransient(typeof(TINavigationWindowSettingsViewModel), typeof(TNavigationWindowSettingsViewModel));
    }
}