using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.Window;

public interface IMessageDialogWindowViewModel : IDialogWindowViewModel
{
    public new IMessageDialogWindowSettingsViewModel Settings { get; }
}