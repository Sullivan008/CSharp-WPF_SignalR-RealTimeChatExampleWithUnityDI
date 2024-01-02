using App.Client.Wpf.Modules.Identity.Presenters.SignIn.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenters.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddIdentityModulePresenters(this IServiceCollection @this)
    {
        @this.AddSignInPresenter();
    }
}