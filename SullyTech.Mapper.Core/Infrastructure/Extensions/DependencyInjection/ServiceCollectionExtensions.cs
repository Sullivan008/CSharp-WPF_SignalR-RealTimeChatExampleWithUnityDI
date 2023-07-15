using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Extensions.Enumerable;
using SullyTech.Mapper.Core.Interfaces;

namespace SullyTech.Mapper.Core.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMapper<TSource, TResult, TIMapper, TMapper>(this IServiceCollection @this)
        where TIMapper : IMapper<TSource, TResult>
        where TMapper : TIMapper
    {
        @this.AddTransient(typeof(TIMapper), typeof(TMapper));
    }

    public static IServiceCollection AddMappersFromAssembly(this IServiceCollection @this, Assembly assembly)
    {
        Type dataMapperType = typeof(IMapper<,>);

        List<TypeInfo> implementationTypes =
            assembly.DefinedTypes.Where(x => x.IsClass)
                                 .Where(x => !x.IsAbstract)
                                 .Where(x => x != dataMapperType)
                                 .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == dataMapperType))
                                 .ToList();

        implementationTypes.ForEach(implementationType =>
        {
            implementationType.ImplementedInterfaces.ForEach(implementedInterfaceType =>
            {
                @this.AddTransient(implementedInterfaceType, implementationType);
            });
        });

        return @this;
    }
}