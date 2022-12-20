using SullyTech.Wpf.Dialogs.MessageDialog.Result.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Commands.Window;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Window;

public sealed class MessageDialogWindowViewModel : DialogWindowViewModel<IMessageDialogWindowSettingsViewModel, IMessageDialogResult>, IMessageDialogWindowViewModel
{
    public MessageDialogWindowViewModel(IMessageDialogWindowSettingsViewModel settings) : base(settings)
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}