using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Implementations.Main.Window;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindowSettings;
using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData.Validator;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Window.Infrastructure.Extensions.DependencyInjection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Implementations.Main.Infrastructure.Extensions.DependencyInjection;

public static class MainWindowServiceCollectionExtension
{
    public static IServiceCollection AddMainWindow(this IServiceCollection @this)
    {
        @this.AddNavigationWindow<MainWindow>();
        @this.AddNavigationWindowViewModel<MainWindowViewModel>();
        
        @this.AddCurrentNavigationWindowService<MainWindow>();

        @this.AddNavigationWindowViewModelInitializer<MainWindowViewModel, MainWindowViewModelInitializerModel>();
        @this.AddNavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel>();

        @this.AddContentPresenterViewModelInitializers();
        @this.AddContentPresenterViewDataViewModelInitializers();

        @this.AddContentPresenterViewDataViewModel<SignInViewDataViewModel>();
        @this.AddTransient<IValidator<SignInViewDataViewModel>, SignInViewDataViewModelValidator>();

        @this.AddContentPresenterViewModelFactory<SignInViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) => 
                new SignInViewModel((SignInViewDataViewModel) contentPresenterViewDataViewModel, (ICurrentNavigationWindowService) currentWindowService,
                                    serviceProvider.GetRequiredService<IChatHub>()));

        return @this;
    }
}