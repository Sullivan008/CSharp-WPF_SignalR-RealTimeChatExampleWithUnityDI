using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.Presenter;

public interface IChatPresenterViewModel : IPresenterViewModel
{
    public new IChatPresenterDataViewModel Data { get; }
}