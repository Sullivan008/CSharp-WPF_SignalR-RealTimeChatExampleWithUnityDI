using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.Presenter;

public interface IChatViewModel : IPresenterViewModel
{
    public new IChatDataViewModel Data { get; }
}