using System.ComponentModel;
using FluentValidation;
using FluentValidation.Results;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;

public class SignInViewDataViewModel : PresenterDataViewModel, IDataErrorInfo
{
    private readonly IValidator<SignInViewDataViewModel> _validator;

    public SignInViewDataViewModel(IValidator<SignInViewDataViewModel> validator)
    {
        _validator = validator;
    }

    private string _nickName = string.Empty;
    public string NickName
    {
        get => _nickName;
        set
        {
            _nickName = value;

            OnPropertyChanged();
        }
    }

    internal bool IsValid => _validator.Validate(this).IsValid;

    public string this[string columnName]
    {
        get
        {
            ValidationResult validationResult = _validator.Validate(this);

            if (!validationResult.IsValid)
            {
                IReadOnlyList<ValidationFailure> validationFailures = validationResult.Errors;

                if (validationFailures.Any(x => x.PropertyName == columnName))
                {
                    return validationFailures.First(x => x.PropertyName == columnName).ErrorMessage;
                }
            }

            return string.Empty;
        }
    }

    public string Error
    {
        get
        {
            ValidationResult validationResult = _validator.Validate(this);

            if (validationResult != null && validationResult.Errors.Any())
            {
                return string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
            }

            return string.Empty;
        }
    }
}