using Application.Client.Windows.Implementations.Main.Window;
using Application.Client.Windows.Implementations.Main.Window.ViewModels;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializers;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializers.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Initializers.ViewModelInitializers.NavigationWindowPageViewModelInitializer.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Application.Client.Windows.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.Main.Infrastructure.Extensions.DependencyInjection;

public static class MainWindowServiceCollectionExtension
{
    public static IServiceCollection AddMainWindow(this IServiceCollection @this)
    {
        @this.RegisterViewNavigationService<MainWindow>();
        @this.RegisterNavigationWindow<MainWindow, MainWindowViewModel>();

        @this.RegisterNavigationWindowPageViewModelInitializers(NavigationWindowPageViewModelInitializers);
        @this.RegisterNavigationWindowPageViewModelFactories(NavigationWindowPageViewModelFactories);

        return @this;
    }
    
    private static IReadOnlyDictionary<Type, Type> NavigationWindowPageViewModelInitializers => new Dictionary<Type, Type>
    {
        { typeof(INavigationWindowPageViewModelInitializer<MainWindow, SignInViewModel, SignInViewModelInitializerModel>), typeof(SignInViewModelInitializer) }
    };

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