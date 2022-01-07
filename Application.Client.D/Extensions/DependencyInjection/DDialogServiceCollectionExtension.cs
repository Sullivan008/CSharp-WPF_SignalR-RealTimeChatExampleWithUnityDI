using Application.Client.D.Windows;
using Application.Client.D.Windows.ViewModels;
using Application.Client.D.Windows.Views.First.ViewModels;
using Application.Client.D.Windows.Views.Second.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.D.Extensions.DependencyInjection;

public static class FindDialogServiceCollectionExtension
{
    public static IServiceCollection AddDDialog(this IServiceCollection @this)
    {
        @this.AddViewNavigationService<DWindow>();
        @this.AddNavigationWindow<DWindow, DWindowViewModel>();

        @this.AddPageViewModelFactories(NavigationWindowPageViewModelFactories);

        return @this;
    }

    private static IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<DWindow>, PageViewModelBase<DWindow>>>> NavigationWindowPageViewModelFactories
    {
        get
        {
            Func<IViewNavigationService<DWindow>, FirstViewModel> CreateFirstViewModel(IServiceProvider serviceProvider) => viewNavigationService => new FirstViewModel(viewNavigationService);
            Func<IViewNavigationService<DWindow>, SecondViewModel> CreateSecondViewModel(IServiceProvider serviceProvider) => viewNavigationService => new SecondViewModel(viewNavigationService);

            return new Dictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<DWindow>, PageViewModelBase<DWindow>>>>
            {
                { typeof(Func<IViewNavigationService<DWindow>, FirstViewModel>), CreateFirstViewModel },
                { typeof(Func<IViewNavigationService<DWindow>, SecondViewModel>), CreateSecondViewModel }
            };
        }
    }
}