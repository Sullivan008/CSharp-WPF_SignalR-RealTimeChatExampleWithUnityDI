using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.Commands;

internal class OnConnectionLostCommand : AsyncCommand<ChatViewModel>
{
    private readonly IToastNotificationService _toastNotificationService;

    private readonly ICurrentNavigationWindowService _currentWindowService;

    public OnConnectionLostCommand(ChatViewModel callerViewModel, IToastNotificationService toastNotificationService,
        ICurrentNavigationWindowService currentWindowService) : base(callerViewModel)
    {
        _currentWindowService = currentWindowService;
        _toastNotificationService = toastNotificationService;
    }

    public override async Task ExecuteAsync()
    {
        await System.Windows.Application.Current.Dispatcher.InvokeAsync(async () =>
        {
            await ShowConnectionLostMessage();

            await NavigateToSignInView();

            await WindowReSize();
        });
    }

    private async Task ShowConnectionLostMessage()
    {
        ShowNotificationOptions showNotificationOptions = new()
        {
            Title = "Application message",
            Message = "The application has been lost the connection with server! Please sign in again!",
            NotificationType = NotificationType.Error
        };

        await _toastNotificationService.ShowNotification(showNotificationOptions);
    }

    private async Task NavigateToSignInView()
    {
        INavigateToOptions navigateOptions = new NavigateToOptions<SignInViewModel>();

        await _currentWindowService.NavigateToAsync(navigateOptions);

    }

    private async Task WindowReSize()
    {
        await _currentWindowService.SetWindowWidthAsync(400);
        await _currentWindowService.SetWindowHeightAsync(750);
    }
}