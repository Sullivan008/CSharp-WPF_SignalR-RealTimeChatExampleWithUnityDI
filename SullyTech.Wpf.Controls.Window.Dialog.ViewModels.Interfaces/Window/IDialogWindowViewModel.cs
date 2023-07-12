using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Result.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;

public interface IDialogWindowViewModel : IWindowViewModel
{
    public IDialogResult DialogResult { get; set; }
}