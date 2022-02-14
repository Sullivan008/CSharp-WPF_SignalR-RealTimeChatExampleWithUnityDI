using Application.Client.Windows.Core.Window.Extensions;

namespace Application.Client.Windows.Implementations.Exception.Window;

public partial class ExceptionWindow : DialogWindow.Window.DialogWindow
{
    public ExceptionWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}