using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.Infrastructure.Extensions.DependencyInjection;

public static class PageViewModelServiceCollectionExtension
{
    public static void AddPageViewModelFactories<TNavigationWindow, TPageViewModel>(this IServiceCollection @this,
        IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<TNavigationWindow>, TPageViewModel>>> pageViewModelFactories) where TNavigationWindow : NavigationWindow
                                                                                                                                                   where TPageViewModel : PageViewModelBase<TNavigationWindow>
    {
        pageViewModelFactories.Keys.ForEach(key =>
        {
            @this.AddTransient(key, pageViewModelFactories[key]);
        });
    }
}