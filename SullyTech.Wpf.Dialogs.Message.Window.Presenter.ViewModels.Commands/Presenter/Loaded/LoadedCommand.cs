using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Commands.Presenter.Loaded;

public sealed class LoadedCommand : AsyncCommand<IMessageDialogPresenterViewModel, IMessageDialogPresenter>
{
    public LoadedCommand(IMessageDialogPresenterViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IMessageDialogPresenter presenter)
    {
        await ((IMessageDialogPresenterViewModel)presenter.DataContext).Data.OnAfterLoadAsync();
        await ((IMessageDialogPresenterViewModel)presenter.DataContext).OnAfterLoadAsync();
        await presenter.OnAfterLoadAsync();

        await presenter.OnSetFocusAsync();
    }
}