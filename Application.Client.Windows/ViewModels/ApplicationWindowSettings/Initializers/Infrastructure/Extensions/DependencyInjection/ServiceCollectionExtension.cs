using System.Reflection;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationWindowSettingsViewModelInitializers(this IServiceCollection @this, Assembly sourceAssembly)
    {
        Type applicationWindowSettingsViewModelInitializerType = typeof(IApplicationWindowSettingsViewModelInitializer<,>);

        IReadOnlyCollection<TypeInfo> implementationTypeInfos = sourceAssembly.DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Where(x => x != applicationWindowSettingsViewModelInitializerType)
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == applicationWindowSettingsViewModelInitializerType))
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