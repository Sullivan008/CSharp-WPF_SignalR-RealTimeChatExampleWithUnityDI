using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Common.Utilities.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPageViewModelFactory(this IServiceCollection @this, Type pageViewModelFactoryType,
        Func<IServiceProvider, Func<IViewNavigationService, IPageViewModel>> pageViewModelFactory)
    {
        @this.AddTransient(pageViewModelFactoryType, pageViewModelFactory);
    }

    public static void AddPageViewModelFactories(this IServiceCollection @this,
        IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService, IPageViewModel>>> pageViewModelFactories)
    {
        pageViewModelFactories.Keys.ForEach(key =>
        {
            @this.AddPageViewModelFactory(key, pageViewModelFactories[key]);
        });
    }
}