using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Commands.Loaded;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.Presenter;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter;

namespace App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Presenter;

public sealed class ChatPresenterViewModel : PresenterViewModel<IChatPresenterDataViewModel>, IChatPresenterViewModel
{
    public ChatPresenterViewModel(IChatPresenterDataViewModel data) : base(data)
    {
        LoadedCommand = new LoadedCommand(this);
    }
}