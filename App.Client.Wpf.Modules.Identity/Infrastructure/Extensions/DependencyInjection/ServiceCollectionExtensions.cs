using App.Client.Wpf.Modules.Identity.Presenter.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddIdentityModule(this IServiceCollection @this)
    {
        @this.AddIdentityModulePresenters();
    }
}