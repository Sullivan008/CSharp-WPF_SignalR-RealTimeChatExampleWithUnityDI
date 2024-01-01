using SullyTech.Wpf.Controls.Window.Core.Extensions.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;

namespace SullyTech.Wpf.Dialogs.Message.Window.UserControls;

public sealed partial class MessageDialogWindow : DialogWindow
{
    public MessageDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}