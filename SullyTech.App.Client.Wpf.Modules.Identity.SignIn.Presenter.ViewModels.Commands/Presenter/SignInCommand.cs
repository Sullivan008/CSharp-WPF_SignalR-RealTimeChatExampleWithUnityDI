using System;
using System.Threading.Tasks;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Interfaces;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.App.Client.Wpf.Modules.Chat.Chat.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.NavigateToOptions;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfaces;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Commands.Presenter;

public sealed class SignInCommand : AsyncCommand<ISignInViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    public SignInCommand(ISignInViewModel callerViewModel, IChatHub chatHub, IToastNotification toastNotification,
        INavigationWindowService navigationWindowService) : base(callerViewModel)
    {
        _chatHub = chatHub;
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;
    }

    public override async Task ExecuteAsync()
    {
        if (_chatHub.IsConnected == false)
        {
            await ShowChatServerIsNotAvailableToastMessage();
            return;
        }

        await SignInAsync();

        INavigationWindow presenterWindow = await GetPresenterWindow();

        await NavigateToChatView(presenterWindow);
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

        await _toastNotification.ShowNotificationAsync(showNotificationOptions);
    }

    private async Task SignInAsync()
    {
        SignInRequestModel requestModel = new()
        {
            NickName = CallerViewModel.Data.NickName
        };

        await _chatHub.SignInAsync(requestModel);
    }

    private async Task<INavigationWindow> GetPresenterWindow()
    {
        return await _navigationWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);
    }

    private async Task NavigateToChatView(INavigationWindow presenterWindow)
    {
        INavigateToOptions navigateOptions = new NavigateToOptions<IChatViewModel, IChatDataViewModel>();

        await _navigationWindowService.NavigateToAsync(presenterWindow, navigateOptions);
    }
}