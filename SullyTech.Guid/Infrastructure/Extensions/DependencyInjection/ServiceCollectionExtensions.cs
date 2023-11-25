using Microsoft.Extensions.DependencyInjection;
using SullyTech.Guid.Interfaces;

namespace SullyTech.Guid.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddGuid(this IServiceCollection @this)
    {
        @this.AddSingleton<IGuid, Guid>();
    }
}