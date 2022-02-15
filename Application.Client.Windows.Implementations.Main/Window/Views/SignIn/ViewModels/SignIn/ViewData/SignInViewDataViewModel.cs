using System.ComponentModel;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;

public class SignInViewDataViewModel : ContentPresenterViewDataViewModel, IDataErrorInfo
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