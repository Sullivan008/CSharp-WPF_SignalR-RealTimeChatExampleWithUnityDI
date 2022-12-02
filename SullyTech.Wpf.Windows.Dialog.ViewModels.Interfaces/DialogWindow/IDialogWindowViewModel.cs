using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;

namespace SullyTech.Wpf.Windows.Dialog.ViewModels.Interfaces.DialogWindow;

public interface IDialogWindowViewModel : IWindowViewModel
{
    public IDialogResult DialogResult { get; set; }
}