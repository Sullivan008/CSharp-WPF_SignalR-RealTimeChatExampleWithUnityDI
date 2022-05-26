using System.Windows.Input;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.Commands;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;

public class ChatViewModel : ContentPresenterViewModel<ChatViewDataViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotificationService _toastNotificationService;

    public ChatViewModel(ChatViewDataViewModel viewData, ICurrentWindowService currentWindowService,
        IChatHub chatHub, IToastNotificationService toastNotificationService) : base(viewData, currentWindowService)
    {
        _chatHub = chatHub;
        _toastNotificationService = toastNotificationService;

        InitChatHubEvents();
    }

    private void InitChatHubEvents()
    {
        _chatHub.ConnectionLost += OnConnectionLost;
    }

    private async Task OnConnectionLost(Exception? ex)
    {
        if (OnConnectionLostCommand.CanExecute(default))
        {
            OnConnectionLostCommand.Execute(ex);
            _chatHub.ConnectionLost -= OnConnectionLost;
        }

        await Task.CompletedTask;
    }

    private ICommand? _onConnectionLostCommand;
    public ICommand OnConnectionLostCommand => _onConnectionLostCommand ??=
        new OnConnectionLostCommand(this, _toastNotificationService, (ICurrentNavigationWindowService) CurrentWindowService);
}