using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.Implementations.Main.Window.Views.Chat.ViewModels.Chat.ViewData;

namespace Application.Client.Windows.Implementations.Main.Window.Views.Chat.ViewModels.Chat;

public class ChatViewModel : ContentPresenterViewModel<ChatViewDataViewModel>
{
    public ChatViewModel(ChatViewDataViewModel viewData, ICurrentWindowService currentWindowService) : base(viewData,
        currentWindowService)
    {
        currentWindowService.SetWindowHeight(250);
    }
}