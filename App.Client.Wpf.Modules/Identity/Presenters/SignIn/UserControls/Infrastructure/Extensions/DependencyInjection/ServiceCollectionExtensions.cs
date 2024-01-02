using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.UserControls.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.UserControls.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddSignInPresenterUserControl(this IServiceCollection @this)
    {
        @this.AddPresenter<SignInPresenter>();
    }
}