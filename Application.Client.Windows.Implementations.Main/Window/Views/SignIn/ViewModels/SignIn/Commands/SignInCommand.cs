using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;
using Application.Client.Windows.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.Windows.ToastNotification.Services.ToastNotification.Options.Models;
using Application.Client.Windows.ToastNotification.Services.ToastNotification.Options.Models.Enums;

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
            ShowNotificationOptions showNotificationOptions = new()
            {
                Title = "Internal server error!",
                Message = "The chat server is not available! Please try again later!",
                NotificationType = NotificationType.Error
            };

            await _toastNotificationService.ShowNotification(showNotificationOptions);

            return;
        }

        await Task.CompletedTask;
    }

    public override Predicate<object?>? CanExecute => _ => CallerViewModel.ViewData.IsValid;
}