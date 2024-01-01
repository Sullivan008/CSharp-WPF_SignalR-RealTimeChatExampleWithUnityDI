using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Services.Window.Destroyer.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddWindowDestroyerService(this IServiceCollection @this)
    {
        @this.AddScoped<IWindowDestroyerService, WindowDestroyerService>();
    }
}