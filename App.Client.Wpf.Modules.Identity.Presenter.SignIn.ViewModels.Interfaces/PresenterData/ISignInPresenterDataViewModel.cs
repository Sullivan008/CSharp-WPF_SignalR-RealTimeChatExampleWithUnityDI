using System.ComponentModel;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.ValidatablePresenterData;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.PresenterData;

public interface ISignInPresenterDataViewModel : IValidatablePresenterDataViewModel, IDataErrorInfo
{
    public string NickName { get; set; }
}