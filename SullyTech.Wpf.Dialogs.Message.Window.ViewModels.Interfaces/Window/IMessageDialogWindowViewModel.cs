using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.Window;

public interface IMessageDialogWindowViewModel : IDialogWindowViewModel
{
    public new IMessageDialogWindowSettingsViewModel Settings { get; }
}