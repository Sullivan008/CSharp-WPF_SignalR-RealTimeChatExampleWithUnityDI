using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class SignInCommand : AsyncContentPresenterCommand<SignInViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotificationService _toastNotificationService;

    public SignInCommand(SignInViewModel callerViewModel, IChatHub chatHub, IToastNotificationService toastNotificationService) : base(callerViewModel)
    {
        _chatHub = chatHub;
        _toastNotificationService = toastNotificationService;
    }

    public override async Task ExecuteAsync()
    {
        if (_chatHub.IsConnected == false)
        {
            await ShowChatServerIsNotAvailableToastMessage();
            return;
        }

        SignInRequestModel requestModel = new()
        {
            NickName = CallerViewModel.ViewData.NickName
        };

        await _chatHub.SignInAsync(requestModel);
    }

    public override Predicate<object?> CanExecute => _ => CallerViewModel.ViewData.IsValid;

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
}