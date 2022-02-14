using Application.Client.Windows.Core.Window.Extensions;

namespace Application.Client.Windows.Implementations.ExceptionDialog.Window;

public partial class ExceptionDialogWindow : DialogWindow.Window.DialogWindow
{
    public ExceptionDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}