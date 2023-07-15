using Microsoft.Extensions.DependencyInjection;
using SullyTech.Mapper.Services.Mapper.Interfaces;

namespace SullyTech.Mapper.Services.Mapper.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMapperService(this IServiceCollection @this)
    {
        @this.AddScoped<IMapperService, MapperService>();
    }
}