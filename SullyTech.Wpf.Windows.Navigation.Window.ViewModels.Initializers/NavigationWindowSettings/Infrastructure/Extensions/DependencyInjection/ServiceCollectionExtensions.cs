using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Interfaces.NavigationWindowSettings;

namespace SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Initializers.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindowSettingsViewModelInitializer<TINavigationWindowSettingsViewModel, TINavigationWindowSettingsViewModelInitializerModel,
        TINavigationWindowSettingsViewModelInitializer, TNavigationWindowSettingsViewModelInitializer>(this IServiceCollection @this)
            where TINavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
            where TINavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
            where TINavigationWindowSettingsViewModelInitializer : INavigationWindowSettingsViewModelInitializer<TINavigationWindowSettingsViewModel, TINavigationWindowSettingsViewModelInitializerModel>
            where TNavigationWindowSettingsViewModelInitializer : TINavigationWindowSettingsViewModelInitializer
    {
        @this.AddScoped(typeof(TINavigationWindowSettingsViewModelInitializer), typeof(TNavigationWindowSettingsViewModelInitializer));
    }
}