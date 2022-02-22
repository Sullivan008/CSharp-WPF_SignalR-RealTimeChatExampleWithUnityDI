using System.Reflection;
using Application.Cache.Core.Repositories.ApplicationCache.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Cache.Core.Repositories.ApplicationCache.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationCacheRepositories(this IServiceCollection @this)
    {
        Type applicationCacheRepositoryType = typeof(IApplicationCacheRepository<,>);

        List<TypeInfo> implementationTypes = Assembly.GetCallingAssembly().DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Where(x => x != applicationCacheRepositoryType)
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == applicationCacheRepositoryType))
            .ToList();

        implementationTypes.ForEach(implementationType =>
        {
            implementationType.ImplementedInterfaces.ForEach(implementedInterfaceType =>
            {
                @this.AddSingleton(implementedInterfaceType, implementationType);
            });
        });

        return @this;
    }
}