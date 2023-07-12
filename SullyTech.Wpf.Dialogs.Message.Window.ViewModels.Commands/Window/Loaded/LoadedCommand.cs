using SullyTech.Wpf.Controls.Window.Core.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Message.Window.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Commands.Window.Loaded;

public sealed class LoadedCommand : AsyncCommand<IMessageDialogWindowViewModel, IMessageDialogWindow>
{
    public LoadedCommand(IMessageDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IMessageDialogWindow window)
    {
        await ((IDialogWindowViewModel)window.DataContext).Settings.OnAfterLoadAsync();
        await ((IDialogWindowViewModel)window.DataContext).OnAfterLoadAsync();
    }
}