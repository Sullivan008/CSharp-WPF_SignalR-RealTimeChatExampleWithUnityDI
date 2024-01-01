using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window.Commands;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window;

public sealed class ExceptionDialogWindowViewModel : DialogWindowViewModel
{
    public ExceptionDialogWindowViewModel(IWindowDestroyerService windowDestroyerService)
    {
        LoadedCommand = new LoadedCommand(this);
        ClosingCommand = new ClosingCommand(this, windowDestroyerService);
    }
}