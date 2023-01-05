using System.Windows.Input;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Commands.Presenter;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Presenter;

public sealed class ChatViewModel : PresenterViewModel<IChatDataViewModel>, IChatViewModel
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    public ChatViewModel(IChatDataViewModel data, INavigationWindowService navigationWindowService,
        IChatHub chatHub, IToastNotification toastNotification) : base(data)
    {
        _chatHub = chatHub;
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;
    }

    private ICommand? _onConnectionLostCommand;
    public ICommand OnConnectionLostCommand => _onConnectionLostCommand ??=
        new OnConnectionLostCommand(this, _toastNotification, _navigationWindowService);

    public override async Task OnInit()
    {
        await InitWindowSize();

        await InitChatHubEvents();
    }

    private async Task InitWindowSize()
    {
        INavigationWindow presenterWindow = await _navigationWindowService.GetWindowAsync(PresenterWindowId);

        await _navigationWindowService.SetWindowWidthAsync(presenterWindow, 1000);
        await _navigationWindowService.SetWindowHeightAsync(presenterWindow, 250);
    }

    private async Task InitChatHubEvents()
    {
        _chatHub.ConnectionLost += OnConnectionLost;

        await Task.CompletedTask;
    }
    
    public override async Task OnDestroy()
    {
        _chatHub.ConnectionLost -= OnConnectionLost;

        await Task.CompletedTask;
    }

    private async Task OnConnectionLost(Exception? ex)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(async () =>
        {
            OnConnectionLostCommand.Execute(ex);

            await Task.CompletedTask;
        });
    }
}