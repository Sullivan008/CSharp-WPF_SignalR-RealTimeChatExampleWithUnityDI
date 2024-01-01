using SullyTech.Wpf.Controls.Window.Core.Extensions.Window;
using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;

namespace SullyTech.Wpf.Dialogs.Exception.Window.UserControls;

public sealed partial class ExceptionDialogWindow : DialogWindow
{
    public ExceptionDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}