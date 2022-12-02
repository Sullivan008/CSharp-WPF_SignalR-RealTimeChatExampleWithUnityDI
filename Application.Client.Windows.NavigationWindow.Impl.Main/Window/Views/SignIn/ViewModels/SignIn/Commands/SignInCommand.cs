using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class SignInCommand : AsyncCommand<SignInViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotificationService _toastNotificationService;

    private readonly ICurrentNavigationWindowService _currentWindowService;

    public SignInCommand(SignInViewModel callerViewModel, IChatHub chatHub, IToastNotificationService toastNotificationService,
        ICurrentNavigationWindowService currentWindowService) : base(callerViewModel)
    {
        _chatHub = chatHub;
        _currentWindowService = currentWindowService;
        _toastNotificationService = toastNotificationService;
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

        await _toastNotificationService.ShowNotification(showNotificationOptions);
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