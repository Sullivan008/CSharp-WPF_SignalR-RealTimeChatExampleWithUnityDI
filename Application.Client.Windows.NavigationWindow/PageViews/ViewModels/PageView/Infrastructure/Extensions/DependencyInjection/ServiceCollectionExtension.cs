using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPageViewViewModelFactory<TPageViewViewModel>(this IServiceCollection @this, 
        Func<IServiceProvider, Func<ICurrentNavigationWindowService, TPageViewViewModel>> pageViewViewModelFactory) where TPageViewViewModel : IPageViewViewModel
    {
        @this.AddTransient(pageViewViewModelFactory);
    }
}