using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.MethodParameters.NavigateToOptions.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.Commands;

internal class OnConnectionLostCommand : AsyncCommand<ChatViewModel>
{
    private readonly IToastNotification _toastNotification;

    private readonly ICurrentNavigationWindowService _currentWindowService;

    public OnConnectionLostCommand(ChatViewModel callerViewModel, IToastNotification toastNotification,
        ICurrentNavigationWindowService currentWindowService) : base(callerViewModel)
    {
        _currentWindowService = currentWindowService;
        _toastNotification = toastNotification;
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

        await _toastNotification.ShowNotificationAsync(showNotificationOptions);
    }

    private async Task NavigateToSignInView()
    {
        INavigateToOptions navigateOptions = new NavigateToOptions<SignInViewModel>();

        await _currentWindowService.NavigateToAsync(navigateOptions);

    }

    private async Task WindowReSize()
    {
        await _currentWindowService.SetWindowWidthAsync(450);
        await _currentWindowService.SetWindowHeightAsync(750);
    }
}