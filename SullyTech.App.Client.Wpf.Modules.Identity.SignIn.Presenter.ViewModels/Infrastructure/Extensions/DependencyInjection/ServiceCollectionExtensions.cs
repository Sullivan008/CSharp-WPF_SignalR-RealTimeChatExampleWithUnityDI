using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Presenter;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSignInViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterViewModel<ISignInViewModel, SignInViewModel>();
    }

    public static void AddSignInDataViewModel(this IServiceCollection @this)
    {
        @this.AddPresenterDataViewModel<ISignInDataViewModel, SignInDataViewModel>();
    }
}