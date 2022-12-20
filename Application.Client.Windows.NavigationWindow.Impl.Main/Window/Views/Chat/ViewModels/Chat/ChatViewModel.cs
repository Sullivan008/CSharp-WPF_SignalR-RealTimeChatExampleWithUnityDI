using System.Windows.Input;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.Commands;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;

public class ChatViewModel : PresenterViewModel<ChatViewDataViewModel>, IChatViewModel
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    public ChatViewModel(ChatViewDataViewModel viewData, INavigationWindowService navigationWindowService,
        IChatHub chatHub, IToastNotification toastNotification) : base(viewData)
    {
        _chatHub = chatHub;
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;

        InitChatHubEvents();
    }

    IPresenterDataViewModel IPresenterViewModel.Data => Data;

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
        new OnConnectionLostCommand(this, _toastNotification, _navigationWindowService);

}

public interface IChatViewModel : IPresenterViewModel
{

}