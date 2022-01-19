﻿using System.Reflection;
using Application.Client.Windows.Implementations.Main.Infrastructure.Interfaces.Markers;
using Application.Client.Windows.Implementations.Main.Window;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
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
        @this.AddViewNavigationService<MainWindow>();
        
        @this.AddNavigationWindow<MainWindow, MainWindowViewModel>();

        @this.AddNavigationWindowViewModelInitializers(CurrentAssembly);
        @this.AddNavigationWindowSettingsViewModelInitializers(CurrentAssembly);

        @this.AddPageViewViewModelInitializers(CurrentAssembly);
        @this.AddPageViewDataViewModelInitializers(CurrentAssembly);

        @this.AddPageViewViewModelFactory<SignInViewModel>(serviceProvider => 
            viewNavigationService => new SignInViewModel(viewNavigationService, serviceProvider.GetRequiredService<INavigationWindowService>()));

        return @this;
    }
}