using App.Client.Wpf.Windows.Main.Services.MainWindow.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Windows.Main.Window.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindow(this IServiceCollection @this)
    {
        @this.AddMainWindowWindow();

        @this.AddMainWindowService();
    }
}