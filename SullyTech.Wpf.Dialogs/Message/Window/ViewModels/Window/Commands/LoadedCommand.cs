using SullyTech.Wpf.Controls.Window.Core.Commands.Abstractions;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Dialogs.Message.Window.UserControls;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Commands;

internal sealed class LoadedCommand : AsyncCommand<MessageDialogWindowViewModel, MessageDialogWindow>
{
    public LoadedCommand(MessageDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(MessageDialogWindow window)
    {
        await ((DialogWindowViewModel)window.DataContext).OnAfterLoadAsync();
    }
}