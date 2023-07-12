using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.WindowManager.Interfaces;

namespace SullyTech.Wpf.Services.WindowManager.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddWindowManagerService(this IServiceCollection @this)
    {
        @this.AddScoped<IWindowManagerService, WindowManagerService>();
    }
}