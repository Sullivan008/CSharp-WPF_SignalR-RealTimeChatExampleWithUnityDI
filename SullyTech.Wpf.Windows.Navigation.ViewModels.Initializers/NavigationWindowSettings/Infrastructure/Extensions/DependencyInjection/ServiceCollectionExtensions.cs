using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindowSettings;

namespace SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindowSettingsViewModelInitializer<TINavigationWindowSettingsViewModel, TINavigationWindowSettingsViewModelInitializerModel>(this IServiceCollection @this)
        where TINavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
        where TINavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
    {
        Type implementationInterfaceType =
            typeof(INavigationWindowSettingsViewModelInitializer<TINavigationWindowSettingsViewModel, TINavigationWindowSettingsViewModelInitializerModel>);

        Type implementationType =
            Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                      .Where(x => !x.IsAbstract)
                                                      .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}