using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;

public class ChatViewModel : ContentPresenterViewModel<ChatViewDataViewModel>
{
    public ChatViewModel(ChatViewDataViewModel viewData, ICurrentWindowService currentWindowService) : base(viewData,
        currentWindowService)
    {
        currentWindowService.SetWindowWidth(1000);
        currentWindowService.SetWindowHeight(250);
    }
}