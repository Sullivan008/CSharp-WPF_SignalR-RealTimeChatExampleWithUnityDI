using SullyTech.Wpf.Controls.Presenter.Core.Commands.Abstractions;
using SullyTech.Wpf.Dialogs.Exception.Presenter.UserControls;

namespace SullyTech.Wpf.Dialogs.Exception.Presenter.ViewModels.Presenter.Commands;

internal sealed class LoadedCommand : AsyncCommand<ExceptionDialogPresenterViewModel, ExceptionDialogPresenter>
{
    public LoadedCommand(ExceptionDialogPresenterViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(ExceptionDialogPresenter presenter)
    {
        await ((ExceptionDialogPresenterViewModel)presenter.DataContext).OnAfterLoadAsync();
        await presenter.OnAfterLoadAsync();

        await presenter.OnSetFocusAsync();
    }
}