using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Models.Interfaces;
using SullyTech.Wpf.Windows.Simple.ViewModels.Interfaces.SimpleWindow;

namespace SullyTech.Wpf.Windows.Simple.ViewModels.Initializers.SimpleWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowViewModelInitializer<TSimpleWindowViewModel, TSimpleWindowViewModelInitializerModel>(this IServiceCollection @this)
        where TSimpleWindowViewModel : ISimpleWindowViewModel
        where TSimpleWindowViewModelInitializerModel : ISimpleWindowViewModelInitializerModel
    {
        Type implementationInterfaceType =
            typeof(ISimpleWindowViewModelInitializer<TSimpleWindowViewModel, TSimpleWindowViewModelInitializerModel>);

        Type implementationType =
            Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                      .Where(x => !x.IsAbstract)
                                                      .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}