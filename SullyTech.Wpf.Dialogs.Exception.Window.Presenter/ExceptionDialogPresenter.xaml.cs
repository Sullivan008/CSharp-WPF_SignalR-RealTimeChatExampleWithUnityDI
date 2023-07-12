using SullyTech.Wpf.Dialogs.Exception.Window.Presenter.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window.Presenter;

public partial class ExceptionDialogPresenter : SullyTech.Wpf.Controls.Window.Core.Presenter.Presenter, IExceptionDialogPresenter
{
    public ExceptionDialogPresenter()
    {
        InitializeComponent();
    }
}