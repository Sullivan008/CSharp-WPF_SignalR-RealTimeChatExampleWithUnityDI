using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;

public class ChatViewDataViewModel : PresenterDataViewModel, IChatDataViewModel
{ }

public interface IChatDataViewModel : IPresenterDataViewModel
{

}