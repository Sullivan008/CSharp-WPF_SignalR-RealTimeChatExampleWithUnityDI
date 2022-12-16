using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindowSettings;

namespace SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindowSettingsViewModel<TNavigationWindowSettingsViewModel>(this IServiceCollection @this)
        where TNavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
    {
        @this.AddTransient(typeof(TNavigationWindowSettingsViewModel));
    }
}