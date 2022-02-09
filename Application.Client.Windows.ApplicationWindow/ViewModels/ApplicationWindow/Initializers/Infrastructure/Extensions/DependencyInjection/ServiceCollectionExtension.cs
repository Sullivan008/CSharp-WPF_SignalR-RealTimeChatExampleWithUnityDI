using System.Reflection;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindowViewModelInitializer<TApplicationWindowViewModel, TApplicationWindowViewModelInitializerModel>(this IServiceCollection @this)
        where TApplicationWindowViewModel : IApplicationWindowViewModel
        where TApplicationWindowViewModelInitializerModel : IApplicationWindowViewModelInitializerModel
    {
        Type implementationInterfaceType = typeof(IApplicationWindowViewModelInitializer<TApplicationWindowViewModel, TApplicationWindowViewModelInitializerModel>);

        Type implementationType = Assembly.GetCallingAssembly().DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);

        return @this;
    }
}