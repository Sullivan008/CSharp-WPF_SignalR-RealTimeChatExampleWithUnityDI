using FluentValidation;

namespace App.BusinessLogic.Modules.Identity.User.Commands.SignIn.Validators;

public sealed class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.UserName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("The 'User Name' is required!");
    }
}