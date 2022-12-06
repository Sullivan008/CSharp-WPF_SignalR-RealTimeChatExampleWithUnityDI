using SullyTech.Wpf.Dialogs.MessageDialog.Result;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Window.Commands;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.DialogWindow;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Window;

public sealed class MessageDialogWindowViewModel : DialogWindowViewModel<MessageDialogWindowSettingsViewModel, MessageDialogResult>
{
    public MessageDialogWindowViewModel()
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}