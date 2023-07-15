using Microsoft.Extensions.DependencyInjection;
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
}