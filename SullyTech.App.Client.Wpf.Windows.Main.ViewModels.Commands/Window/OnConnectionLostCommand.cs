using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Windows.Core.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Commands.Window;

public sealed class OnConnectionLostCommand : AsyncCommand<IMainWindowViewModel>
{
    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    public OnConnectionLostCommand(IMainWindowViewModel callerViewModel, IToastNotification toastNotification,
        INavigationWindowService navigationWindowService) : base(callerViewModel)
    {
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;
    }

    public override async Task ExecuteAsync()
    {
        await ShowConnectionLostMessage();

        INavigationWindow presenterWindow = await GetPresenterWindow();

        await NavigateToSignInView(presenterWindow);
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
}