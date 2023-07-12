using App.Client.Wpf.Windows.Main.Services.MainWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Windows.Main.Services.MainWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMainWindowService(this IServiceCollection @this)
    {
        @this.AddScoped<IMainWindowService, MainWindowService>();
    }
}