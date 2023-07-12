using SullyTech.Wpf.Controls.Window.Core.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Commands.Window.Loaded;

public sealed class LoadedCommand : AsyncCommand<IExceptionDialogWindowViewModel, IExceptionDialogWindow>
{
    public LoadedCommand(IExceptionDialogWindowViewModel callerViewModel) : base(callerViewModel)
    { }

    public override async Task ExecuteAsync(IExceptionDialogWindow window)
    {
        await ((IDialogWindowViewModel)window.DataContext).Settings.OnAfterLoadAsync();
        await ((IDialogWindowViewModel)window.DataContext).OnAfterLoadAsync();
    }
}