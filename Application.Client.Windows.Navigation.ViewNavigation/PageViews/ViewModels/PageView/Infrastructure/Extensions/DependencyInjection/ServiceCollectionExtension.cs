using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPageViewViewModelFactory<TPageViewViewModel>(this IServiceCollection @this, 
        Func<IServiceProvider, Func<IViewNavigationService, TPageViewViewModel>> pageViewViewModelFactory) where TPageViewViewModel : IPageViewViewModel
    {
        @this.AddTransient(pageViewViewModelFactory);
    }
}