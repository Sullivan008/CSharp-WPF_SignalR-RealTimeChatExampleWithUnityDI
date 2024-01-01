using SullyTech.Wpf.Controls.Window.Core.Commands.Abstractions;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.UserControls;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Commands;

internal sealed class LoadedCommand : AsyncCommand<ExceptionDialogWindowViewModel, ExceptionDialogWindow>
{
    public LoadedCommand(ExceptionDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(ExceptionDialogWindow window)
    {
        await ((DialogWindowViewModel)window.DataContext).OnAfterLoadAsync();
    }
}