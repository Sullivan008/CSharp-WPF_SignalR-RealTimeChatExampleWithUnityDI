using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.Infrastructure.Extensions.DependencyInjection;

public static class PageViewModelServiceCollectionExtension
{
    public static void AddPageViewModelFactories<TPageViewModel>(this IServiceCollection @this,
        IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService, TPageViewModel>>> pageViewModelFactories) where TPageViewModel : PageViewModelBase
    {
        pageViewModelFactories.Keys.ForEach(key =>
        {
            @this.AddTransient(key, pageViewModelFactories[key]);
        });
    }
}