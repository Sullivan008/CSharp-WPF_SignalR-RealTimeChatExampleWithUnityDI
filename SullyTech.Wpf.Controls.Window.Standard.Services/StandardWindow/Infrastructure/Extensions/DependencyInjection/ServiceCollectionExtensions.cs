using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddStandardWindowService(this IServiceCollection @this)
    {
        @this.AddScoped<IStandardWindowService, StandardWindowService>();
    }
}