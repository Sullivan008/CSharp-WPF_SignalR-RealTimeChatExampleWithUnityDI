using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.PresenterData;

public interface ISignInDataViewModel : IPresenterDataViewModel
{
    public string NickName { get; set; }

    public bool IsValid { get; }
}