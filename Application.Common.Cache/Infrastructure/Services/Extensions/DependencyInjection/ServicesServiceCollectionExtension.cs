using Application.Common.Cache.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Cache.Infrastructure.Services.Extensions.DependencyInjection;

public static class ServicesServiceCollectionExtension
{
    public static IServiceCollection AddCacheServices(this IServiceCollection @this)
    {
        @this.AddSingleton<IApplicationCacheService, ApplicationCacheService>();

        return @this;
    }
}