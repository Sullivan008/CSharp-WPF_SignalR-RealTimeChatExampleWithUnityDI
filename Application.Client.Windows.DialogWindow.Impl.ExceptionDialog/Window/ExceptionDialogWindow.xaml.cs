using SullyTech.Wpf.Windows.Core.Extensions.Window;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window;

public partial class ExceptionDialogWindow : SullyTech.Wpf.Windows.Dialog.Window.DialogWindow
{
    public ExceptionDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}