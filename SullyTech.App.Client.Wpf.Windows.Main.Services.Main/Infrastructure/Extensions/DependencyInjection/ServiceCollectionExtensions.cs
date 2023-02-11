using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Services.Main.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.Services.Main.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowService(this IServiceCollection @this)
    {
        @this.AddScoped<IMainWindowService, MainWindowService>();
    }
}