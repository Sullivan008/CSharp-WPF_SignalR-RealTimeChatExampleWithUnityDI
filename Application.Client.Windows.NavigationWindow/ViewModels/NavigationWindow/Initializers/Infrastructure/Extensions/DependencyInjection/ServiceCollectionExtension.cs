using System.Reflection;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddNavigationWindowViewModelInitializers(this IServiceCollection @this, Assembly sourceAssembly)
    {
        Type navigationWindowViewModelInitializerType = typeof(INavigationWindowViewModelInitializer<,>);

        IReadOnlyCollection<TypeInfo> implementationTypeInfos = sourceAssembly.DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Where(x => x != navigationWindowViewModelInitializerType)
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == navigationWindowViewModelInitializerType))
            .ToHashSet();

        implementationTypeInfos.ForEach(implementationTypeInfo =>
        {
            implementationTypeInfo.ImplementedInterfaces.ForEach(implementedInterface =>
            {
                @this.AddTransient(implementedInterface, implementationTypeInfo);
            });
        });

        return @this;
    }
}