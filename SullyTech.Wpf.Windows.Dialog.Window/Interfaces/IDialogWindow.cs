using SullyTech.Wpf.Windows.Core.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Dialog.Window.Interfaces;

public interface IDialogWindow : IWindow
{
    public bool? DialogResult { get; set; }

    public bool? ShowDialog();
}