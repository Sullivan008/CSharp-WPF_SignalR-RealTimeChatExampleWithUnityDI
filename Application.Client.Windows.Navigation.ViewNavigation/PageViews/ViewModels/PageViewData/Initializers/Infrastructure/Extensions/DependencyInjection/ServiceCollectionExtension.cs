using System.Reflection;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Initializers.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Initializers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPageViewDataViewModelInitializers(this IServiceCollection @this, Assembly sourceAssembly)
    {
        Type pageViewDataViewModelInitializerType = typeof(IPageViewDataViewModelInitializer<,>);

        IReadOnlyCollection<TypeInfo> implementationTypeInfos = sourceAssembly.DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Where(x => x != pageViewDataViewModelInitializerType)
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == pageViewDataViewModelInitializerType))
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