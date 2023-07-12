using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.Window.Closer.Interfaces;

namespace SullyTech.Wpf.Services.Window.Closer.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddWindowCloserService(this IServiceCollection @this)
    {
        @this.AddScoped<IWindowCloserService, WindowCloserService>();
    }
}