using App.Client.Wpf.Modules.Identity.Presenter.SignIn.Interfaces;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Validators.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSignInPresenter(this IServiceCollection @this)
    {
        @this.AddPresenter<ISignInPresenter, SignInPresenter>();

        @this.AddSignInPresenterViewModel();
        @this.AddSignInPresenterDataViewModel();

        @this.AddSignInPresenterDataViewModelValidator();
    }
}