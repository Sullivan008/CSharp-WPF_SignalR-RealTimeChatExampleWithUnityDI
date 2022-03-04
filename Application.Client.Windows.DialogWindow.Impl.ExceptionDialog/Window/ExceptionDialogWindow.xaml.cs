using Application.Client.Windows.Core.Window.Extensions;

namespace Application.Client.Windows.DialogWindow.Impl.ExceptionDialog.Window;

public partial class ExceptionDialogWindow : Core.Window.DialogWindow
{
    public ExceptionDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}