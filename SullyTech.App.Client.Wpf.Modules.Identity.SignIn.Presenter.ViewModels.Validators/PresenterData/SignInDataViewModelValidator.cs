using FluentValidation;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Validators.PresenterData;

internal sealed class SignInDataViewModelValidator : AbstractValidator<ISignInDataViewModel>
{
    public SignInDataViewModelValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.NickName)
            .NotNull()
            .NotEmpty()
            .WithMessage("This field is required!")
            .MinimumLength(6)
            .WithMessage("The nickname must be at least 6 characters long!");
    }
}