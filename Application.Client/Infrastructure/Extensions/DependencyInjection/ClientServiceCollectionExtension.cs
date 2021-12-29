using Application.Client.Windows.Main;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.Views.SignIn.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Application.Client.Windows.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Infrastructure.Extensions.DependencyInjection;

public static class ClientServiceCollectionExtension
{
    public static IServiceCollection AddMainWindow(this IServiceCollection @this)
    {
        @this.AddNavigationWindow<MainWindow, MainWindowViewModel>(NavigationWindowPageViewModelFactories);
        
        return @this;
    }

    private static IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<MainWindow>, NavigationWindowPageViewModelBase<MainWindow>>>> NavigationWindowPageViewModelFactories
    {
        get
        {
            Func<IViewNavigationService<MainWindow>, SignInViewModel> CreateSignInViewModel(IServiceProvider serviceProvider) =>
                viewNavigationService => new SignInViewModel(viewNavigationService, serviceProvider.GetRequiredService<IApplicationWindowService>());

            return new Dictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<MainWindow>, NavigationWindowPageViewModelBase<MainWindow>>>>
            {
                { typeof(Func<IViewNavigationService<MainWindow>, SignInViewModel>), CreateSignInViewModel }
            };
        }
    }
}