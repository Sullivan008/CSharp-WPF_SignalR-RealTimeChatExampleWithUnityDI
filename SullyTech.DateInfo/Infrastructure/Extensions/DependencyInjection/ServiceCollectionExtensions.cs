using Microsoft.Extensions.DependencyInjection;
using SullyTech.DateInfo.Interfaces;

namespace SullyTech.DateInfo.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddDateInfo(this IServiceCollection @this)
    {
        @this.AddSingleton<IDateInfo, DateInfo>();
    }
}