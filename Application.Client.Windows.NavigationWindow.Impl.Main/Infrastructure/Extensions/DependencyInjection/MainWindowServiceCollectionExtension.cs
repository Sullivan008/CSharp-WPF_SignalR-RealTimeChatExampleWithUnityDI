using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Infrastructure.Extensions.DependencyInjection;

public static class MainWindowServiceCollectionExtension
{
    public static IServiceCollection AddMainWindowPres(this IServiceCollection @this)
    {


        @this.AddPresenterViewModel<ISignInViewModel, SignInViewModel>();
        @this.AddPresenterDataViewModel<ISignInDataViewModel, SignInViewDataViewModel>();

        @this.AddPresenterViewModel<IChatViewModel, ChatViewModel>();
        @this.AddPresenterDataViewModel<IChatDataViewModel, ChatViewDataViewModel>();

        @this.AddTransient<IValidator<SignInViewDataViewModel>, SignInViewDataViewModelValidator>();

        return @this;
    }
}