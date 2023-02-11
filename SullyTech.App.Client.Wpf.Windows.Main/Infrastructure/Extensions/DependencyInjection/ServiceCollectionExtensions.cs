using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Services.Main.Infrastructure.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Windows.Main.Window.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Windows.Main.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindow(this IServiceCollection @this)
    {
        @this.AddMainWindowWindowDependencies();

        @this.AddMainWindowService();
    }
}