using SullyTech.Wpf.Dialogs.MessageDialog.Window.Interfaces;
using SullyTech.Wpf.Windows.Core.Extensions.Window;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window;

public sealed partial class MessageDialogWindow : SullyTech.Wpf.Windows.Dialog.Window.DialogWindow, IMessageDialogWindow
{
    public MessageDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}