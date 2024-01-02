using App.Client.Wpf.Modules.Identity.Presenters.SignIn.UserControls;
using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels.Commands;

internal sealed class LoadedCommand : AsyncCommand<SignInPresenterViewModel, SignInPresenter>
{
    public LoadedCommand(SignInPresenterViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(SignInPresenter presenter)
    {
        await ((SignInPresenterViewModel)presenter.DataContext).OnAfterLoadAsync();
        await presenter.OnAfterLoadAsync();

        await presenter.OnSetFocusAsync();
    }
}