using App.Client.SignalR.Hubs.Chat.Interfaces;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.Interfaces;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.Presenter;
using App.Client.Wpf.Modules.Chat.Presenter.Chat.ViewModels.Interfaces.PresenterData;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.Presenter;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Services.Navigation.Interfaces;
using SullyTech.Wpf.Services.Navigation.Models.MethodParameters.NavigateToOptions;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Commands.Presenter.SignIn;

public sealed class SignInCommand : AsyncCommand<ISignInPresenterViewModel>
{
    private readonly IToastNotification _toastNotification;

    private readonly INavigationService _navigationService;


    private readonly IChatHub _chatHub;

    public SignInCommand(ISignInPresenterViewModel callerViewModel, IToastNotification toastNotification,
        INavigationService navigationService, IChatHub chatHub) : base(callerViewModel)
    {
        _toastNotification = toastNotification;
        _navigationService = navigationService;

        _chatHub = chatHub;
    }

    public override Predicate<object?> CanExecute => _ => CallerViewModel.Data.IsValid;

    public override async Task ExecuteAsync()
    {
        if (_chatHub.IsConnected == false)
        {
            // TODO - Replace to Validation (or other) exception, and handling this the Global Exception Handling!
            await ShowChatServerIsNotAvailableToastMessage();
        }
        else
        {
            await SignInAsync();

            await NavigateToChatView();
        }
    }

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

    private async Task NavigateToChatView()
    {
        await _navigationService.NavigateToAsync(
            windowId: CallerViewModel.WindowId,
            navigateToOptions: new NavigateToOptions<IChatPresenter, IChatPresenterViewModel, IChatPresenterDataViewModel>());
    }
}