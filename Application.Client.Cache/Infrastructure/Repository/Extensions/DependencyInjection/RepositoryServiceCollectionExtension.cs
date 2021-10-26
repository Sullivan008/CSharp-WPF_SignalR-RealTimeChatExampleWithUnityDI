using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Application.Client.Cache.Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Cache.Infrastructure.Repository.Extensions.DependencyInjection
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddCacheRepositories(this IServiceCollection @this)
        {
            Type repositoryType = typeof(ICacheRepository<>);

            List<TypeInfo> definedTypes = repositoryType.Assembly.DefinedTypes
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
}
