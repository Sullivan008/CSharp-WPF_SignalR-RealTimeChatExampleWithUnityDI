using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Services.Window.Title.Interfaces;

namespace SullyTech.Wpf.Services.Window.Title.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddWindowTitleService(this IServiceCollection @this)
    {
        @this.AddScoped<IWindowTitleService, WindowTitleService>();
    }
}