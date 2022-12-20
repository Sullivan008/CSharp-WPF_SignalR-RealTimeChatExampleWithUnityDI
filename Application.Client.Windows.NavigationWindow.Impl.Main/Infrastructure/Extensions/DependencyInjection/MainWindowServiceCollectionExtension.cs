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
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Initializers.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindow.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindowSettings.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Navigation.Window.Infrastructure.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Infrastructure.Extensions.DependencyInjection;

public static class MainWindowServiceCollectionExtension
{
    public static IServiceCollection AddMainWindow(this IServiceCollection @this)
    {
        @this.AddNavigationWindow<IMainWindow, MainWindow>();

        @this.AddNavigationWindowViewModel<IMainWindowViewModel, MainWindowViewModel>();
        @this.AddNavigationWindowSettingsViewModel<IMainWindowSettingsViewModel, MainWindowSettingsViewModel>();

        @this.AddNavigationWindowSettingsViewModelInitializer<IMainWindowSettingsViewModel, IMainWindowSettingsViewModelInitializerModel>();

        @this.AddPresenterViewModel<ISignInViewModel, SignInViewModel>();
        @this.AddPresenterDataViewModel<ISignInDataViewModel, SignInViewDataViewModel>();

        @this.AddPresenterViewModel<IChatViewModel, ChatViewModel>();
        @this.AddPresenterDataViewModel<IChatDataViewModel, ChatViewDataViewModel>();

        @this.AddTransient<IValidator<SignInViewDataViewModel>, SignInViewDataViewModelValidator>();

        return @this;
    }
}