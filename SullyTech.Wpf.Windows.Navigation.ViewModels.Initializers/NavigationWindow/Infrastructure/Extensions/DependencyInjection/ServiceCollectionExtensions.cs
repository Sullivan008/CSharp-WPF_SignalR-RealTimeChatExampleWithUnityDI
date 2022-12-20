using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;

namespace SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindowViewModelInitializer<TINavigationWindowViewModel, TINavigationWindowViewModelInitializerModel>(this IServiceCollection @this)
        where TINavigationWindowViewModel : INavigationWindowViewModel
        where TINavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
    {
        Type implementationInterfaceType =
            typeof(INavigationWindowViewModelInitializer<TINavigationWindowViewModel, TINavigationWindowViewModelInitializerModel>);

        Type implementationType =
            Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                      .Where(x => !x.IsAbstract)
                                                      .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}