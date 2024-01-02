using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddSignInPresenterViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<SignInPresenterViewModel>();
    }
}