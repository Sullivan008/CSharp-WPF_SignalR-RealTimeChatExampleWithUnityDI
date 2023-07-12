using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.PresenterData;
using FluentValidation;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Validators.PresenterData;

internal sealed class SignInPresenterDataViewModelValidator : AbstractValidator<ISignInPresenterDataViewModel>
{
    public SignInPresenterDataViewModelValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.NickName)
            .NotEmpty()
                .WithMessage("This field is required!")
            .MinimumLength(6)
                .WithMessage("This field minimum length is {MinLength}!");
    }
}