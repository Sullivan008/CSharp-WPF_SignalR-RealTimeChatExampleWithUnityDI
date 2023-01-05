using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Validators.PresenterData;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Validators.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSignInDataViewModelValidator(this IServiceCollection @this)
    {
        @this.AddTransient<IValidator<ISignInDataViewModel>, SignInDataViewModelValidator>();
    }
}