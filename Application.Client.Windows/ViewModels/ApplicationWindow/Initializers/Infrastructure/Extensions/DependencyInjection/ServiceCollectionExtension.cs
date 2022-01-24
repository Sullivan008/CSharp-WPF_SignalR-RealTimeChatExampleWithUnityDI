using System.Reflection;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindowViewModelInitializers(this IServiceCollection @this, Assembly sourceAssembly)
    {
        Type applicationWindowViewModelInitializerType = typeof(IApplicationWindowViewModelInitializer<,>);

        IReadOnlyCollection<TypeInfo> implementationTypeInfos = sourceAssembly.DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Where(x => x != applicationWindowViewModelInitializerType)
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == applicationWindowViewModelInitializerType))
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