using App.Client.Wpf.Modules.Chat.Presenter.Chat.Interfaces;

namespace App.Client.Wpf.Modules.Chat.Presenter.Chat;

public sealed partial class ChatPresenter : SullyTech.Wpf.Controls.Window.Core.Presenter.Presenter, IChatPresenter
{
    public ChatPresenter()
    {
        InitializeComponent();
    }
}