using App.Client.Wpf.Modules.Identity.Presenter.SignIn.Interfaces;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.Presenter;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.PresenterData;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Services.Navigation.Interfaces;
using SullyTech.Wpf.Services.Navigation.Models.MethodParameters.NavigateToOptions;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Commands.Window.OnConnectionLost;

public sealed class OnConnectionLostCommand : AsyncCommand<IMainWindowViewModel>
{
    private readonly IToastNotification _toastNotification;

    private readonly INavigationService _navigationService;

    public OnConnectionLostCommand(IMainWindowViewModel callerViewModel, IToastNotification toastNotification,
        INavigationService navigationService) : base(callerViewModel)
    {
        _toastNotification = toastNotification;
        _navigationService = navigationService;
    }

    public override async Task ExecuteAsync()
    {
        await ShowConnectionLostMessage();

        await NavigateToSignInView();
    }

    private async Task ShowConnectionLostMessage()
    {
        await _toastNotification.ShowNotificationAsync(
            showNotificationOptions: new ShowNotificationOptions
            {
                Title = "Application message",
                Message = "The application has been lost the connection with server! Please sign in again!",
                NotificationType = NotificationType.Error
            });
    }

    private async Task NavigateToSignInView()
    {
        await _navigationService.NavigateToAsync(
            windowId: CallerViewModel.WindowId,
            navigateToOptions: new NavigateToOptions<ISignInPresenter, ISignInPresenterViewModel, ISignInPresenterDataViewModel>());
    }
}