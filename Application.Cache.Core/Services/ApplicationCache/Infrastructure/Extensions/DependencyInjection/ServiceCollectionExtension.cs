using Application.Cache.Core.Services.ApplicationCache.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Cache.Core.Services.ApplicationCache.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationCacheService(this IServiceCollection @this)
    {
        @this.AddSingleton<IApplicationCacheService, ApplicationCacheService>();

        return @this;
    }
}