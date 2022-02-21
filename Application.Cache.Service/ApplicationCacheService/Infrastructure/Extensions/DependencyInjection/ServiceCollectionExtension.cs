using Application.Cache.Services.ApplicationCacheService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Cache.Services.ApplicationCacheService.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationCacheService(this IServiceCollection @this)
    {
        @this.AddSingleton<IApplicationCacheService, ApplicationCacheService>();

        return @this;
    }
}