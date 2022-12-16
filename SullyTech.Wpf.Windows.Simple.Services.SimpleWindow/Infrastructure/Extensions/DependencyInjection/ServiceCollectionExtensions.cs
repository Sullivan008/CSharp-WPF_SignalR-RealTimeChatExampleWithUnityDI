using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.Services.SimpleWindow.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Services.SimpleWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowService(this IServiceCollection @this)
    {
        @this.AddScoped<ISimpleWindowService, SimpleWindowService>();
    }
}