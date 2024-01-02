using FluentValidation;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Validators;

internal sealed class SignInPresenterViewModelValidator : AbstractValidator<SignInPresenterViewModel>
{
    public SignInPresenterViewModelValidator()
    {
        RuleFor(x => x.NickName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("This field is required!")
            .MinimumLength(6).WithMessage("This field minimum length is {MinLength}!");
    }
}