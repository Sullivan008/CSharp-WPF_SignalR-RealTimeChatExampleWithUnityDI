using Application.Client.Windows.Core.Window.Extensions;

namespace Application.Client.Windows.Implementations.MessageDialog.Window;

public partial class MessageDialogWindow : DialogWindow.Window.DialogWindow
{
    public MessageDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}