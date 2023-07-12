using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.Presenter;

public interface ISignInPresenterViewModel : IPresenterViewModel
{
    public new ISignInPresenterDataViewModel Data { get; }
}