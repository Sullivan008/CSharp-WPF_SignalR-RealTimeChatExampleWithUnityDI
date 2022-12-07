using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings.Initializer.Models;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.Infrastructure.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Infrastructure.Extensions.DependencyInjection;

public static class MainWindowServiceCollectionExtension
{
    public static IServiceCollection AddMainWindow(this IServiceCollection @this)
    {
        @this.AddNavigationWindow<MainWindow>();
        @this.AddNavigationWindowViewModel<MainWindowViewModel>();

        @this.AddCurrentNavigationWindowService<MainWindow>();

        @this.AddNavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel>();

        @this.AddPresenterDataViewModel<SignInViewDataViewModel>();
        @this.AddPresenterDataViewModel<ChatViewDataViewModel>();

        @this.AddTransient<IValidator<SignInViewDataViewModel>, SignInViewDataViewModelValidator>();

        @this.AddPresenterViewModel<SignInViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) =>
                new SignInViewModel((SignInViewDataViewModel)contentPresenterViewDataViewModel, (ICurrentNavigationWindowService)currentWindowService,
                                    serviceProvider.GetRequiredService<IChatHub>(), serviceProvider.GetRequiredService<IToastNotification>()));

        @this.AddPresenterViewModel<ChatViewModel>(serviceProvider =>
            (contentPresenterViewDataViewModel, currentWindowService) =>
                new ChatViewModel((ChatViewDataViewModel)contentPresenterViewDataViewModel, (ICurrentNavigationWindowService)currentWindowService,
                                  serviceProvider.GetRequiredService<IChatHub>(), serviceProvider.GetRequiredService<IToastNotification>()));

        return @this;
    }
}