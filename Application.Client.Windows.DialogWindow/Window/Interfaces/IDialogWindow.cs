using Application.Client.Windows.Core.Window.Interfaces;

namespace Application.Client.Windows.DialogWindow.Window.Interfaces;

public interface IDialogWindow : IWindow
{
    public bool? DialogResult { get; set; }

    public bool? ShowDialog();
}