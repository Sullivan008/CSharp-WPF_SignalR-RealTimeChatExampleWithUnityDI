using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.Interfaces;

namespace SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Presenter;

public sealed class ChatViewModel : PresenterViewModel<IChatDataViewModel>, IChatViewModel
{
    private readonly INavigationWindowService _navigationWindowService;

    public ChatViewModel(IChatDataViewModel data, INavigationWindowService navigationWindowService) : base(data)
    {
        _navigationWindowService = navigationWindowService;
    }

    public override async Task OnInit()
    {
        await InitWindowSize();
    }

    private async Task InitWindowSize()
    {
        INavigationWindow presenterWindow = await _navigationWindowService.GetWindowAsync(PresenterWindowId);

        await _navigationWindowService.SetWindowWidthAsync(presenterWindow, 1000);
        await _navigationWindowService.SetWindowHeightAsync(presenterWindow, 250);
    }
}