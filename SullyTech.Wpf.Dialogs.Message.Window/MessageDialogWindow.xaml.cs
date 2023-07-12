using SullyTech.Wpf.Controls.Window.Core.Extensions.Window;
using SullyTech.Wpf.Dialogs.Message.Window.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window;

public sealed partial class MessageDialogWindow : SullyTech.Wpf.Controls.Window.Dialog.DialogWindow, IMessageDialogWindow
{
    public MessageDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}