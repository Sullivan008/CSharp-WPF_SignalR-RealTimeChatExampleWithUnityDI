using System.Reflection;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowViewModelInitializer<TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel>(this IServiceCollection @this)
        where TNavigationWindowViewModel : INavigationWindowViewModel
        where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
    {
        Type implementationInterfaceType = typeof(INavigationWindowViewModelInitializer<TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);

        return @this;
    }
}