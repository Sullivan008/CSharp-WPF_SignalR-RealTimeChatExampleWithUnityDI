using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;
using SullyTech.Wpf.Dialogs.Message.Presenter.UserControls;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Commands;

internal sealed class LoadedCommand : AsyncCommand<MessageDialogPresenterViewModel, MessageDialogPresenter>
{
    public LoadedCommand(MessageDialogPresenterViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(MessageDialogPresenter presenter)
    {
        await ((MessageDialogPresenterViewModel)presenter.DataContext).OnAfterLoadAsync();
        await presenter.OnAfterLoadAsync();

        await presenter.OnSetFocusAsync();
    }
}