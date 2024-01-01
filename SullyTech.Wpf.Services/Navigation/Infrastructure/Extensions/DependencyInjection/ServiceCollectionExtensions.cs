using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.Navigation.Interfaces;

namespace SullyTech.Wpf.Services.Navigation.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationService(this IServiceCollection @this)
    {
        @this.AddScoped<INavigationService, NavigationService>();
    }
}