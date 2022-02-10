using Application.Client.Windows.Core.Window.Extensions;

namespace Application.Client.Windows.Implementations.MessageBox.Window;

public partial class MessageBoxWindow : DialogWindow.Window.DialogWindow
{
    public MessageBoxWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}