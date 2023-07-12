using System.ComponentModel;
using System.Runtime.CompilerServices;
using FluentValidation;
using FluentValidation.Results;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.ValidatablePresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.ValidatablePresenterData;

public abstract class ValidatablePresenterDataViewModel<TPresenterDataViewModel> : PresenterDataViewModel, IValidatablePresenterDataViewModel, IDataErrorInfo, INotifyPropertyChanged
    where TPresenterDataViewModel : IValidatablePresenterDataViewModel
{
    private bool _isEnabledValidation;

    protected readonly IValidator<TPresenterDataViewModel> Validator;

    protected ValidatablePresenterDataViewModel(IValidator<TPresenterDataViewModel> validator)
    {
        Validator = validator;
    }
    
    public virtual bool IsValid => Validator.Validate((TPresenterDataViewModel)(IValidatablePresenterDataViewModel)this).IsValid;

    public string this[string columnName]
    {
        get
        {
            if (_isEnabledValidation)
            {
                ValidationResult validationResult = Validator.Validate((TPresenterDataViewModel)(IValidatablePresenterDataViewModel)this);

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

            return string.Empty;
        }
    }

    public string Error
    {
        get
        {
            if (_isEnabledValidation)
            {
                ValidationResult validationResult = Validator.Validate((TPresenterDataViewModel)(IValidatablePresenterDataViewModel)this);

                if (validationResult != null && validationResult.Errors.Any())
                {
                    return string.Join(Environment.NewLine, validationResult.Errors.Select(x => x.ErrorMessage));
                }

                return string.Empty;
            }

            return string.Empty;
        }
    }

    public virtual async Task OnEnableValidationAsync()
    {
        _isEnabledValidation = true;

        await Task.CompletedTask;
    }

    public new event PropertyChangedEventHandler? PropertyChanged;
    public new void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}