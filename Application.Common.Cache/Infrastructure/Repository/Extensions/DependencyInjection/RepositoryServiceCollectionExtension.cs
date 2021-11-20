using System.Reflection;
using Application.Common.Cache.Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Cache.Infrastructure.Repository.Extensions.DependencyInjection;

public static class RepositoryServiceCollectionExtension
{
    public static IServiceCollection AddCacheRepositories(this IServiceCollection @this, Assembly sourceAssembly)
    {
        Type repositoryType = typeof(ICacheRepository<,>);

        List<TypeInfo> definedTypes = sourceAssembly.DefinedTypes
            .Where(x => x.IsClass)
            .Where(x => !x.IsAbstract)
            .Where(x => x != repositoryType)
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == repositoryType))
            .ToList();

        foreach (TypeInfo definedType in definedTypes)
        {
            foreach (Type implementedInterface in definedType.ImplementedInterfaces)
            {
                @this.AddSingleton(implementedInterface, definedType);
            }
        }

        return @this;
    }
}