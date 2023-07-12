using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter.ViewModels.Commands.Presenter.Loaded;

public sealed class LoadedCommand : AsyncCommand<IExceptionDialogPresenterViewModel, IExceptionDialogPresenter>
{
    public LoadedCommand(IExceptionDialogPresenterViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IExceptionDialogPresenter presenter)
    {
        await ((IExceptionDialogPresenterViewModel)presenter.DataContext).Data.OnAfterLoadAsync();
        await ((IExceptionDialogPresenterViewModel)presenter.DataContext).OnAfterLoadAsync();
        await presenter.OnAfterLoadAsync();

        await presenter.OnSetFocusAsync();
    }
}