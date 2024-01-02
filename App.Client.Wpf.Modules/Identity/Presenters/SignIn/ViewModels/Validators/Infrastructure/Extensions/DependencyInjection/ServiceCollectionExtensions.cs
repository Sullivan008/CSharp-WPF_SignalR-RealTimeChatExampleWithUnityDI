using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Validators.Infrastructure.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static void AddSignInPresenterViewModelValidator(this IServiceCollection @this)
    {
        @this.AddScoped<IValidator<SignInPresenterViewModel>, SignInPresenterViewModelValidator>();
    }
}