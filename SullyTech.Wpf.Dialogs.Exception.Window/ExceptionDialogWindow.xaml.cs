using SullyTech.Wpf.Controls.Window.Core.Extensions.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window;

public sealed partial class ExceptionDialogWindow : SullyTech.Wpf.Controls.Window.Dialog.DialogWindow, IExceptionDialogWindow
{
    public ExceptionDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}