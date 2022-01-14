using Application.Client.Windows.Implementations.Main.Window;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Services.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Initializers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.Main.Infrastructure.Extensions.DependencyInjection;

public static class MainWindowServiceCollectionExtension
{
    public static IServiceCollection AddMainWindow(this IServiceCollection @this)
    {
        @this.AddViewNavigationService<MainWindow>();
        
        @this.AddNavigationWindow<MainWindow, MainWindowViewModel, MainWindowSettingsViewModel>();
        @this.AddNavigationWindowViewModelInitializer(NavigationWindowViewModelInitializer);

        @this.AddPageViewModelInitializers(PageViewModelInitializers);
        @this.AddPageViewModelFactories(PageViewModelFactories);

        return @this;
    }

    private static readonly KeyValuePair<Type, Type> NavigationWindowViewModelInitializer = 
        new(typeof(INavigationWindowViewModelInitializer<MainWindowViewModel, MainWindowViewModelInitializerModel>), typeof(MainWindowViewModelInitializer));

    private static IReadOnlyDictionary<Type, Type> PageViewModelInitializers => new Dictionary<Type, Type>
    {
        { typeof(IPageViewModelInitializer<SignInViewModel, SignInViewModelInitializerModel>), typeof(SignInViewModelInitializer) }
    };

    private static IReadOnlyDictionary<Type, Func<IServiceProvider, Func<IViewNavigationService, IPageViewModel>>> PageViewModelFactories
    {
        get
        {
            Func<IViewNavigationService, SignInViewModel> CreateSignInViewModel(IServiceProvider serviceProvider) => 
                viewNavigationService => new SignInViewModel(viewNavigationService, serviceProvider.GetRequiredService<INavigationWindowService>());

            return new Dictionary<Type, Func<IServiceProvider, Func<IViewNavigationService, IPageViewModel>>>
            {
                { typeof(Func<IViewNavigationService, SignInViewModel>), CreateSignInViewModel }
            };
        }
    }
}