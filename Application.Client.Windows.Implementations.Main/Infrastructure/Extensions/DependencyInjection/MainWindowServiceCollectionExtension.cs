using Application.Client.Windows.Implementations.Main.Window;
using Application.Client.Windows.Implementations.Main.Window.ViewModels;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Services.ApplicationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.Main.Infrastructure.Extensions.DependencyInjection;

public static class MainWindowServiceCollectionExtension
{
    public static IServiceCollection AddMainWindow(this IServiceCollection @this)
    {
        @this.AddViewNavigationService<MainWindow>();
        @this.AddNavigationWindow<MainWindow, MainWindowViewModel>();

        @this.AddPageViewModelInitializers(PageViewModelInitializers);
        @this.AddPageViewModelFactories(PageViewModelFactories);

        return @this;
    }
    
    private static IReadOnlyDictionary<Type, Type> PageViewModelInitializers => new Dictionary<Type, Type>
    {
        { typeof(IPageViewModelInitializer<MainWindow, SignInViewModel, SignInViewModelInitializerModel>), typeof(SignInViewModelInitializer) }
    };

    private static IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<MainWindow>, PageViewModelBase<MainWindow>>>> PageViewModelFactories
    {
        get
        {
            Func<IViewNavigationService<MainWindow>, SignInViewModel> CreateSignInViewModel(IServiceProvider serviceProvider) => 
                viewNavigationService => new SignInViewModel(viewNavigationService, serviceProvider.GetRequiredService<IApplicationWindowService>());

            return new Dictionary<Type, Func<IServiceProvider, Func<IViewNavigationService<MainWindow>, PageViewModelBase<MainWindow>>>>
            {
                { typeof(Func<IViewNavigationService<MainWindow>, SignInViewModel>), CreateSignInViewModel }
            };
        }
    }
}