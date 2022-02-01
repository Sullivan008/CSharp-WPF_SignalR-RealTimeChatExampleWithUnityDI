using System.Reflection;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddContentPresenterViewModelInitializers(this IServiceCollection @this, Assembly sourceAssembly)
    {
        Type contentPresenterViewModelInitializerType = typeof(IContentPresenterViewModelInitializer<,>);

        IReadOnlyCollection<TypeInfo> implementationTypeInfos = sourceAssembly.DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Where(x => x != contentPresenterViewModelInitializerType)
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == contentPresenterViewModelInitializerType))
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