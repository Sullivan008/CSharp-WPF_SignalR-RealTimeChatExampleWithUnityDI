using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class SignInCommand : AsyncCommand<SignInViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly ICurrentNavigationWindowService _currentWindowService;

    public SignInCommand(SignInViewModel callerViewModel, IChatHub chatHub, IToastNotification toastNotification,
        ICurrentNavigationWindowService currentWindowService) : base(callerViewModel)
    {
        _chatHub = chatHub;
        _currentWindowService = currentWindowService;
        _toastNotification = toastNotification;
    }

    public override async Task ExecuteAsync()
    {
        if (_chatHub.IsConnected == false)
        {
            await ShowChatServerIsNotAvailableToastMessage();
            return;
        }

        await SignInAsync();

        await NavigateToChatView();

        await WindowReSize();
    }

    public override Predicate<object?> CanExecute => _ => CallerViewModel.Data.IsValid;

    private async Task ShowChatServerIsNotAvailableToastMessage()
    {
        ShowNotificationOptions showNotificationOptions = new()
        {
            Title = "Application message",
            Message = "The chat server is not available! Please try again later!",
            NotificationType = NotificationType.Error
        };

        await _toastNotification.ShowNotificationAsync(showNotificationOptions);
    }

    private async Task SignInAsync()
    {
        SignInRequestModel requestModel = new()
        {
            NickName = CallerViewModel.Data.NickName
        };

        await _chatHub.SignInAsync(requestModel);
    }

    private async Task NavigateToChatView()
    {
        INavigateToOptions navigateOptions = new NavigateToOptions<ChatViewModel>();

        await _currentWindowService.NavigateToAsync(navigateOptions);
    }

    private async Task WindowReSize()
    {
        await _currentWindowService.SetWindowWidthAsync(1000);
        await _currentWindowService.SetWindowHeightAsync(250);
    }
}