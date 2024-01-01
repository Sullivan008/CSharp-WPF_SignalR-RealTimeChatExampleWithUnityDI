using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window.Commands;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window;

public sealed class MessageDialogWindowViewModel : DialogWindowViewModel
{
    public MessageDialogWindowViewModel(IWindowDestroyerService windowDestroyerService)
    {
        LoadedCommand = new LoadedCommand(this);
        ClosingCommand = new ClosingCommand(this, windowDestroyerService);
    }
}