using System.Reflection;
using Application.Client.Windows.Implementations.Main.Infrastructure.Interfaces.Markers;
using Application.Client.Windows.Implementations.Main.Window;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageViewData.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Window.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.Main.Infrastructure.Extensions.DependencyInjection;

public static class MainWindowServiceCollectionExtension
{
    private static readonly Assembly CurrentAssembly;

    static MainWindowServiceCollectionExtension()
    {
        CurrentAssembly = Assembly.GetAssembly(typeof(IAssemblyMarker))!;
    }

    public static IServiceCollection AddMainWindow(this IServiceCollection @this)
    {
        @this.AddNavigationWindow<MainWindow, MainWindowViewModel>();
        
        @this.AddCurrentNavigationWindowService<MainWindow>();

        @this.AddNavigationWindowViewModelInitializers(CurrentAssembly);
        @this.AddNavigationWindowSettingsViewModelInitializers(CurrentAssembly);

        @this.AddPageViewViewModelInitializers(CurrentAssembly);
        @this.AddPageViewDataViewModelInitializers(CurrentAssembly);

        @this.AddPageViewViewModelFactory<SignInViewModel>(serviceProvider => 
            (viewNavigationService, _) => new SignInViewModel(viewNavigationService, serviceProvider.GetRequiredService<INavigationWindowService>()));

        return @this;
    }
}