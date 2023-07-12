using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.Presenter;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.PresenterData;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Presenter;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.PresenterData;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.ValidatablePresenterData.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSignInPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<ISignInPresenterViewModel, SignInPresenterViewModel>();
    }

    public static void AddSignInPresenterDataViewModel(this IServiceCollection @this)
    {
        @this.AddValidatablePresenterDataViewModel<ISignInPresenterDataViewModel, SignInPresenterDataViewModel>();
    }
}