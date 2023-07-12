using App.Client.Wpf.Modules.Chat.Presenter.Chat.Interfaces;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Commands.Abstractions;

namespace App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Commands.Loaded;

public sealed class LoadedCommand : AsyncCommand<IChatPresenterViewModel, IChatPresenter>
{
    public LoadedCommand(IChatPresenterViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IChatPresenter presenter)
    {
        await ((IChatPresenterViewModel)presenter.DataContext).Data.OnAfterLoadAsync();
        await ((IChatPresenterViewModel)presenter.DataContext).OnAfterLoadAsync();
        await presenter.OnAfterLoadAsync();

        await presenter.OnSetFocusAsync();
    }
}