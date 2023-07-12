using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.Window;

public interface IExceptionDialogWindowViewModel : IDialogWindowViewModel
{
    public new IExceptionDialogWindowSettingsViewModel Settings { get; }
}