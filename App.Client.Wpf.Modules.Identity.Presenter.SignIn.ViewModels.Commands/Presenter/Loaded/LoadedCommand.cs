using App.Client.Wpf.Modules.Identity.Presenter.SignIn.Interfaces;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Commands.Abstractions;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Commands.Presenter.Loaded;

public sealed class LoadedCommand : AsyncCommand<ISignInPresenterViewModel, ISignInPresenter>
{
    public LoadedCommand(ISignInPresenterViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(ISignInPresenter presenter)
    {
        await ((ISignInPresenterViewModel)presenter.DataContext).Data.OnAfterLoadAsync();
        await ((ISignInPresenterViewModel)presenter.DataContext).OnAfterLoadAsync();
        await presenter.OnAfterLoadAsync();

        await ((ISignInPresenterViewModel)presenter.DataContext).Data.OnEnableValidationAsync();

        await presenter.OnSetFocusAsync();
    }
}