using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPageViewNavigationService(this IServiceCollection @this)
    {
        @this.AddTransient<IPageViewNavigationService, PageViewNavigationService>();
    }
}