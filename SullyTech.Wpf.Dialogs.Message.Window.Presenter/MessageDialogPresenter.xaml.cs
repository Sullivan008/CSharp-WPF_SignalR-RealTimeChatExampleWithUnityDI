using SullyTech.Wpf.Dialogs.Message.Window.Presenter.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter;

public partial class MessageDialogPresenter : SullyTech.Wpf.Controls.Window.Core.Presenter.Presenter, IMessageDialogPresenter
{
    public MessageDialogPresenter()
    {
        InitializeComponent();
    }
}