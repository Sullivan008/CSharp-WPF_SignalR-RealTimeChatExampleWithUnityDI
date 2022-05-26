using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums;
using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Options.Models;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.Commands;

internal class OnConnectionLostCommand : AsyncContentPresenterCommand<ChatViewModel>
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
        await ShowConnectionLostMessage();
        
        await NavigateToSignInView();

        await WindowReSize();
    }

    private async Task ShowConnectionLostMessage()
    {
        await System.Windows.Application.Current.Dispatcher.InvokeAsync(async () =>
        {
            ShowNotificationOptions showNotificationOptions = new()
            {
                Title = "Application message",
                Message = "The application has been lost the connection with server! Please sign in again!",
                NotificationType = NotificationType.Error
            };

            await _toastNotificationService.ShowNotification(showNotificationOptions);
        });
    }

    private async Task NavigateToSignInView()
    {
        await System.Windows.Application.Current.Dispatcher.InvokeAsync(async () =>
        {
            IContentPresenterNavigateOptions navigateOptions = new ContentPresenterNavigateOptions<SignInViewModel, SignInViewModelInitializerModel>();

            await _currentWindowService.NavigateTo(navigateOptions);
        });
    }

    private async Task WindowReSize()
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(async () =>
        {
            await _currentWindowService.SetWindowWidth(400);
            await _currentWindowService.SetWindowHeight(750);
        });
    }
}