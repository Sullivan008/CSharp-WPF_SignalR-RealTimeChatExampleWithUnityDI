using SullyTech.Wpf.Dialogs.MessageDialog.Window.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Extensions.Window;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window;

public sealed partial class MessageDialogWindow : IMessageDialogWindow
{
    public MessageDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}