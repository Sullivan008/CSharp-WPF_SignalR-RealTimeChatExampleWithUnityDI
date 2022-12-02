using System.Windows.Input;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.Commands;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;

public class ChatViewModel : PresenterViewModel<ChatViewDataViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotificationService _toastNotificationService;

    private readonly ICurrentNavigationWindowService _currentNavigationWindowService;

    public ChatViewModel(ChatViewDataViewModel viewData, ICurrentNavigationWindowService currentWindowService,
        IChatHub chatHub, IToastNotificationService toastNotificationService) : base(viewData)
    {
        _chatHub = chatHub;
        _toastNotificationService = toastNotificationService;
        _currentNavigationWindowService = currentWindowService;

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
        new OnConnectionLostCommand(this, _toastNotificationService, _currentNavigationWindowService);
}