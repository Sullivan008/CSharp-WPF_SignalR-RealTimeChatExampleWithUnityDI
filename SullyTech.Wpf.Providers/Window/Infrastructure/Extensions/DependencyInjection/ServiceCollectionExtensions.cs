using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Providers.Window.Interfaces;

namespace SullyTech.Wpf.Providers.Window.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddWindowProvider(this IServiceCollection @this)
    {
        @this.AddScoped<IWindowProvider, WindowProvider>();
    }
}