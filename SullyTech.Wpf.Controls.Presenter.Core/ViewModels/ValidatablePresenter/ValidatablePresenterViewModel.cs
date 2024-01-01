using System.ComponentModel;
using FluentValidation;
using FluentValidation.Results;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;

namespace SullyTech.Wpf.Controls.Presenter.Core.ViewModels.ValidatablePresenter;

public class ValidatablePresenterViewModel<TValidatablePresenterViewModel> : PresenterViewModel, IDataErrorInfo
    where TValidatablePresenterViewModel : ValidatablePresenterViewModel<TValidatablePresenterViewModel>
{
    private readonly IValidator<TValidatablePresenterViewModel> _validator;

    public ValidatablePresenterViewModel(IValidator<TValidatablePresenterViewModel> validator)
    {
        _validator = validator;
    }

    public bool IsValid => _validator.Validate((TValidatablePresenterViewModel)this).IsValid;

    public string this[string columnName]
    {
        get
        {
            ValidationResult validationResult = _validator.Validate((TValidatablePresenterViewModel)this);

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
            ValidationResult validationResult = _validator.Validate((TValidatablePresenterViewModel)this);

            if (validationResult.Errors.Any())
            {
                return string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
            }

            return string.Empty;
        }
    }
}