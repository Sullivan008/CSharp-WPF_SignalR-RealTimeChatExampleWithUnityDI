using App.Web.Api.Contracts.Identity.User.SignIn.RequestModels;
using FluentValidation;

namespace App.Web.Api.Controllers.Modules.Identity.User.Validators;

public sealed class SignInApiRequestModelValidator : AbstractValidator<SignInApiRequestModel>
{
    public SignInApiRequestModelValidator()
    {
        RuleFor(x => x.UserName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("The 'User Name' is required!")
            .MinimumLength(6).WithMessage("The 'User Name' minimum length is {MinLength}!");
    }
}