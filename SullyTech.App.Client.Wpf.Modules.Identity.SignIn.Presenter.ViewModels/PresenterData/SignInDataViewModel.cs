using System.ComponentModel;
using FluentValidation;
using FluentValidation.Results;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.PresenterData;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.PresenterData;

public sealed class SignInDataViewModel : PresenterDataViewModel, IDataErrorInfo, ISignInDataViewModel
{
    private readonly IValidator<ISignInDataViewModel> _validator;

    public SignInDataViewModel(IValidator<ISignInDataViewModel> validator)
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

    public bool IsValid => _validator.Validate(this).IsValid;

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