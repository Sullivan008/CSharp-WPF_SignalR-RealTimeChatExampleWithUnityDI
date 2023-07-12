using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Window;
using SullyTech.Wpf.Dialogs.Message.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Commands.Window.Closing;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Commands.Window.Loaded;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Window;

public sealed class MessageDialogWindowViewModel : DialogWindowViewModel<IMessageDialogWindowSettingsViewModel, IMessageDialogResult>, IMessageDialogWindowViewModel
{
    public MessageDialogWindowViewModel(IMessageDialogWindowSettingsViewModel settings, IWindowDestroyerService windowDestroyerService) : base(settings)
    {
        LoadedCommand = new LoadedCommand(this);
        ClosingCommand = new ClosingCommand(this, windowDestroyerService);
    }
}