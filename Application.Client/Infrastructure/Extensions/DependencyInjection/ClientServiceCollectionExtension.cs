using Application.Client.Windows.Main;
using Application.Client.Windows.Main.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Infrastructure.Extensions.DependencyInjection
{
    internal static class ClientServiceCollectionExtension
    {
        public static IServiceCollection AddMainWindow(this IServiceCollection @this)
        {
            @this.AddSingleton<MainWindowViewModel>();
            @this.AddSingleton(x => new MainWindow
            {
                DataContext = x.GetRequiredService<MainWindowViewModel>()
            });

            return @this;
        }
    }
}