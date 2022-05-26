using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Options.Models;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.Initializer.Models;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class SignInCommand : AsyncContentPresenterCommand<SignInViewModel>
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

        NavigateToChatView();
    }

    public override Predicate<object?> CanExecute => _ => CallerViewModel.ViewData.IsValid;

    private async Task ShowChatServerIsNotAvailableToastMessage()
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(async () =>
        {
            ShowNotificationOptions showNotificationOptions = new()
            {
                Title = "Application message",
                Message = "The chat server is not available! Please try again later!",
                NotificationType = NotificationType.Error
            };

            await _toastNotificationService.ShowNotification(showNotificationOptions);
        });
    }

    private async Task SignInAsync()
    {
        SignInRequestModel requestModel = new()
        {
            NickName = CallerViewModel.ViewData.NickName
        };

        await _chatHub.SignInAsync(requestModel);
    }

    private async Task NavigateToChatView()
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(async () =>
        {
            IContentPresenterNavigateOptions navigateOptions = new ContentPresenterNavigateOptions<ChatViewModel, ChatViewModelInitializerModel>();

            await _currentWindowService.NavigateTo(navigateOptions);
        });
    }

    }
}