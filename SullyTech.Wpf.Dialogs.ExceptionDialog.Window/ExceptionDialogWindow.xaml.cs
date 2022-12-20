using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.Interfaces;
using SullyTech.Wpf.Windows.Core.Extensions.Window;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window;

public sealed partial class ExceptionDialogWindow : SullyTech.Wpf.Windows.Dialog.Window.DialogWindow, IExceptionDialogWindow
{
    public ExceptionDialogWindow()
    {
        this.HideIcon();

        InitializeComponent();
    }
}