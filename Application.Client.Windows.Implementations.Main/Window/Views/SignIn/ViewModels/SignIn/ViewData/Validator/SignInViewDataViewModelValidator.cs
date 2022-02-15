using FluentValidation;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData.Validator;

public class SignInViewDataViewModelValidator : AbstractValidator<SignInViewDataViewModel>
{
    public SignInViewDataViewModelValidator()
    {
        RuleFor(model => model.NickName)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("This field is required!")
            .NotEmpty()
            .WithMessage("This field is required!");
    }
}