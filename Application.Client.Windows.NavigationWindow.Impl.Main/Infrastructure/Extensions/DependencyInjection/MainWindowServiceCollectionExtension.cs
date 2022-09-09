using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Initializers.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Core.Window.Infrastructure.Extensions.DependencyInjection;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Infrastructure.Extensions.DependencyInjection;

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
        @this.AddContentPresenterViewDataViewModel<ChatViewDataViewModel>();

        @this.AddTransient<IValidator<SignInViewDataViewModel>, SignInViewDataViewModelValidator>();

        @this.AddContentPresenterViewModelFactory<SignInViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) =>
                new SignInViewModel((SignInViewDataViewModel)contentPresenterViewDataViewModel, (ICurrentNavigationWindowService)currentWindowService,
                                    serviceProvider.GetRequiredService<IChatHub>(), serviceProvider.GetRequiredService<IToastNotificationService>()));

        @this.AddContentPresenterViewModelFactory<ChatViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) =>
                new ChatViewModel((ChatViewDataViewModel)contentPresenterViewDataViewModel, (ICurrentNavigationWindowService)currentWindowService,
                                  serviceProvider.GetRequiredService<IChatHub>(), serviceProvider.GetRequiredService<IToastNotificationService>()));

        return @this;
    }
}