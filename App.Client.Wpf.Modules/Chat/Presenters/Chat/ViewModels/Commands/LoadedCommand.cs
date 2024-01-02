using App.Client.Wpf.Modules.Chat.Presenters.Chat.UserControls;
using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;

namespace App.Client.Wpf.Modules.Chat.Presenters.Chat.ViewModels.Commands;

public sealed class LoadedCommand : AsyncCommand<ChatPresenterViewModel, ChatPresenter>
{
    public LoadedCommand(ChatPresenterViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(ChatPresenter presenter)
    {
        await ((ChatPresenterViewModel)presenter.DataContext).OnAfterLoadAsync();
        await presenter.OnAfterLoadAsync();

        await presenter.OnSetFocusAsync();
    }
}