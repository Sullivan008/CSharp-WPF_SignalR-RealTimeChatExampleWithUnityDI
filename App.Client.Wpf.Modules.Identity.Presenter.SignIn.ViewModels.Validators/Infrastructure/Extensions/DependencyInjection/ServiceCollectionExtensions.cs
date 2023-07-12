using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.PresenterData;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Validators.PresenterData;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Validators.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSignInPresenterDataViewModelValidator(this IServiceCollection @this)
    {
        @this.AddScoped<IValidator<ISignInPresenterDataViewModel>, SignInPresenterDataViewModelValidator>();
    }
}