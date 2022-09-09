using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Window.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCurrentNavigationWindowService<TNavigationWindow>(this IServiceCollection @this) 
        where TNavigationWindow : INavigationWindow
    {
        @this.AddTransient<Func<TNavigationWindow, ICurrentNavigationWindowService>>(serviceProvider =>
            navigationWindow => new CurrentNavigationWindowService(navigationWindow, serviceProvider.GetRequiredService<IContentPresenterService>()));

        return @this;
    }
}