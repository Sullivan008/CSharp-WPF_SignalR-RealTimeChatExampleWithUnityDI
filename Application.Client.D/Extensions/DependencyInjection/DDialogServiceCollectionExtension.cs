using Application.Client.D.Windows;
using Application.Client.D.Windows.ViewModels;
using Application.Client.D.Windows.Views.First;
using Application.Client.D.Windows.Views.First.ViewModels;
using Application.Client.D.Windows.Views.Second.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.D.Extensions.DependencyInjection;

public static class FindDialogServiceCollectionExtension
{
    public static IServiceCollection AddDDialog(this IServiceCollection @this)
    {
        @this.AddNavigationWindow<DWindow, DWindowViewModel>(NavigationWindowPageViewModelFactories);

        return @this;
    }

    private static IReadOnlyDictionary<Type, Type> NavigationWindowPageViews => new Dictionary<Type, Type>
    {
        { typeof(FirstView), typeof(FirstViewModel) }
    };

    private static IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<DWindow>, NavigationWindowPageViewModelBase<DWindow>>>> NavigationWindowPageViewModelFactories
    {
        get
        {
            Func<IViewNavigationService<DWindow>, FirstViewModel> CreateFirstViewModel(IServiceProvider serviceProvider) => viewNavigationService => new FirstViewModel(viewNavigationService);
            Func<IViewNavigationService<DWindow>, SecondViewModel> CreateSecondViewModel(IServiceProvider serviceProvider) => viewNavigationService => new SecondViewModel(viewNavigationService);

            return new Dictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<DWindow>, NavigationWindowPageViewModelBase<DWindow>>>>
            {
                { typeof(Func<IViewNavigationService<DWindow>, FirstViewModel>), CreateFirstViewModel },
                { typeof(Func<IViewNavigationService<DWindow>, SecondViewModel>), CreateSecondViewModel }
            };
        }
    }
}