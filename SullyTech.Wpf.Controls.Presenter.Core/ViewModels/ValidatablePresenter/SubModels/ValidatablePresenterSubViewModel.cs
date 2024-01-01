using System.ComponentModel;
using FluentValidation;
using FluentValidation.Results;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.SubModels;

namespace SullyTech.Wpf.Controls.Presenter.Core.ViewModels.ValidatablePresenter.SubModels;

public class ValidatablePresenterSubViewModel<TValidatablePresenterSubViewModel> : PresenterSubViewModel, IDataErrorInfo
    where TValidatablePresenterSubViewModel : ValidatablePresenterSubViewModel<TValidatablePresenterSubViewModel>
{
    private readonly IValidator<TValidatablePresenterSubViewModel> _validator;

    protected ValidatablePresenterSubViewModel(IValidator<TValidatablePresenterSubViewModel> validator)
    {
        _validator = validator;
    }

    public bool IsValid => _validator.Validate((TValidatablePresenterSubViewModel)this).IsValid;

    public string this[string columnName]
    {
        get
        {
            ValidationResult validationResult = _validator.Validate((TValidatablePresenterSubViewModel)this);

            if (!validationResult.IsValid)
            {
                IReadOnlyCollection<ValidationFailure> validationFailures = validationResult.Errors;

                if (validationFailures.Any(x => x.PropertyName == columnName))
                {
                    return validationFailures.First(x => x.PropertyName == columnName)
                                             .ErrorMessage;
                }
            }

            return string.Empty;
        }
    }

    public string Error
    {
        get
        {
            ValidationResult validationResult = _validator.Validate((TValidatablePresenterSubViewModel)this);

            if (!validationResult.IsValid)
            {
                if (validationResult.Errors.Any())
                {
                    return string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
                }
            }

            return string.Empty;
        }
    }
}