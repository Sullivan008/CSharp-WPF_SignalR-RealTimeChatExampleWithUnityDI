using System.ComponentModel;
using System.Runtime.CompilerServices;
using FluentValidation;
using FluentValidation.Results;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.ValidatablePresenterData.SubInterfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData.SubModels;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.ValidatablePresenterData.SubModels;

public class ValidatablePresenterDataSubViewModel<TPresenterDataSubViewModel> : PresenterDataSubViewModel, IValidatablePresenterDataSubViewModel, IDataErrorInfo, INotifyPropertyChanged
    where TPresenterDataSubViewModel : IValidatablePresenterDataSubViewModel
{
    private bool _isEnabledValidation;

    protected readonly IValidator<TPresenterDataSubViewModel> Validator;

    protected ValidatablePresenterDataSubViewModel(IValidator<TPresenterDataSubViewModel> validator)
    {
        Validator = validator;
    }

    public virtual bool IsValid => Validator.Validate((TPresenterDataSubViewModel)(IValidatablePresenterDataSubViewModel)this).IsValid;

    public string this[string columnName]
    {
        get
        {
            if (_isEnabledValidation)
            {
                ValidationResult validationResult = Validator.Validate((TPresenterDataSubViewModel)(IValidatablePresenterDataSubViewModel)this);

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
                ValidationResult validationResult = Validator.Validate((TPresenterDataSubViewModel)(IValidatablePresenterDataSubViewModel)this);

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