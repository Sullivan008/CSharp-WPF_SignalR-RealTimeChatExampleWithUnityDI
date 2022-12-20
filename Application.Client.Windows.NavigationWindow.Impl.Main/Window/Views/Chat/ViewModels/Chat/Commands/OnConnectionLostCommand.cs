using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.Commands;

internal class OnConnectionLostCommand : AsyncCommand<ChatViewModel>
{
    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    public OnConnectionLostCommand(ChatViewModel callerViewModel, IToastNotification toastNotification,
        INavigationWindowService navigationWindowService) : base(callerViewModel)
    {
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;
    }

    public override async Task ExecuteAsync()
    {
        await System.Windows.Application.Current.Dispatcher.InvokeAsync(async () =>
        {
            await ShowConnectionLostMessage();

            INavigationWindow presenterWindow = await GetPresenterWindow();

            await NavigateToSignInView(presenterWindow);
            await WindowReSize(presenterWindow);
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

    private async Task<INavigationWindow> GetPresenterWindow()
    {
        return await _navigationWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);
    }

    private async Task NavigateToSignInView(INavigationWindow presenterWindow)
    {
        INavigateToOptions navigateOptions = new NavigateToOptions<ISignInViewModel, ISignInDataViewModel>();

        await _navigationWindowService.NavigateToAsync(presenterWindow, navigateOptions);
    }

    private async Task WindowReSize(INavigationWindow presenterWindow)
    {
        await _navigationWindowService.SetWindowWidthAsync(presenterWindow, 450);
        await _navigationWindowService.SetWindowHeightAsync(presenterWindow, 750);
    }
}