using SullyTech.Wpf.Windows.Core.Extensions.Window;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window;

public partial class MessageBoxWindow : SullyTech.Wpf.Windows.Dialog.Window.DialogWindow
{
    public MessageBoxWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}