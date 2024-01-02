using App.Client.Wpf.Modules.Identity.Presenters.SignIn.UserControls.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Infrastructure.Extensions.DependencyInjection;
using App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Validators.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddSignInPresenter(this IServiceCollection @this)
    {
        @this.AddSignInPresenterUserControl();
        @this.AddSignInPresenterViewModel();
        @this.AddSignInPresenterViewModelValidator();
    }
}