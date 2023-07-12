using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.PresenterData;
using FluentValidation;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.ValidatablePresenterData;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.PresenterData;

public sealed class SignInPresenterDataViewModel : ValidatablePresenterDataViewModel<ISignInPresenterDataViewModel>, ISignInPresenterDataViewModel
{
    public SignInPresenterDataViewModel(IValidator<ISignInPresenterDataViewModel> validator) : base(validator)
    { }

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
}