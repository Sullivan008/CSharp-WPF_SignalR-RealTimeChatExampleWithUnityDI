using SullyTech.Wpf.Windows.Core.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Dialog.Window.Result.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Window.ViewModels.Interfaces.DialogWindow;

public interface IDialogWindowViewModel : IWindowViewModel
{
    public IDialogResult DialogResult { get; set; }
}