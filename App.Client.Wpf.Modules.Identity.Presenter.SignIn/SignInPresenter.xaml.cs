using App.Client.Wpf.Modules.Identity.Presenter.SignIn.Interfaces;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn;

public sealed partial class SignInPresenter : SullyTech.Wpf.Controls.Window.Core.Presenter.Presenter, ISignInPresenter
{
    public SignInPresenter()
    {
        InitializeComponent();
    }
}