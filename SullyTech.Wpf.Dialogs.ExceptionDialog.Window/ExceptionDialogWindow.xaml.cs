using SullyTech.Wpf.Windows.Core.Extensions.Window;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window;

public sealed partial class ExceptionDialogWindow : SullyTech.Wpf.Windows.Dialog.Window.DialogWindow
{
    public ExceptionDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}