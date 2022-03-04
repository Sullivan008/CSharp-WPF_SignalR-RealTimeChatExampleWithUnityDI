using System.Reflection;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowSettingsViewModelInitializer<TNavigationWindowSettingsViewModel, TNavigationWindowSettingsViewModelInitializerModel>(this IServiceCollection @this)
        where TNavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
        where TNavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
    {
        Type implementationInterfaceType = typeof(INavigationWindowSettingsViewModelInitializer<TNavigationWindowSettingsViewModel, TNavigationWindowSettingsViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);

        return @this; 
    }
}