using Application.Client.Windows.Core.Window.Extensions;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window;

public partial class MessageBoxWindow : DialogWindow.Core.Window.DialogWindow
{
    public MessageBoxWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}