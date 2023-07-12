namespace SullyTech.Wpf.Controls.Window.Dialog.Interfaces;

public interface IDialogWindow : SullyTech.Wpf.Controls.Window.Core.Interfaces.IWindow
{
    public bool? DialogResult { get; set; }

    public bool? ShowDialog();
}