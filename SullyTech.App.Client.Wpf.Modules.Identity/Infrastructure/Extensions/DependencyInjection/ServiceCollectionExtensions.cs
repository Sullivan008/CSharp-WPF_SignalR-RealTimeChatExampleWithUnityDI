using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Identity.Presenter.SignIn.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Modules.Identity.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddIdentityModule(this IServiceCollection @this)
    {
        @this.AddSignIn();
    }

    private static void AddSignIn(this IServiceCollection @this)
    {
        @this.AddSignInPresenter();
    }
}