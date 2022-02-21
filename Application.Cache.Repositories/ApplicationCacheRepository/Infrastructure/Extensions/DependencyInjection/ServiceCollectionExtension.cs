using System.Reflection;
using Application.Cache.Repositories.ApplicationCacheRepository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Cache.Repositories.ApplicationCacheRepository.Infrastructure.Extensions.DependencyInjection;

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

        foreach (TypeInfo implementationType in implementationTypes)
        {
            foreach (Type implementedInterface in implementationType.ImplementedInterfaces)
            {
                @this.AddSingleton(implementedInterface, implementationType);
            }
        }

        return @this;
    }
}