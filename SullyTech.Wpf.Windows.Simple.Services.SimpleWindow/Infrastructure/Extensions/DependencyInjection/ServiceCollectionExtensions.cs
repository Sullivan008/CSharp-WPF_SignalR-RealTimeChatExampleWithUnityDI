using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.Services.SimpleWindow;

namespace SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNavigationWindowService(this IServiceCollection @this)
    {
        @this.AddScoped<INavigationWindowService, SimpleWindowService>();
    }
}