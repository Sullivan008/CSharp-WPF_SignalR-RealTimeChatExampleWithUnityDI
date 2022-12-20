using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.Chat.ViewModels.Chat.ViewData;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Presenter.Models;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.Presenter.Models.Enums;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Initializers.PresenterData.Models;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Dialogs.MessageDialog.Result.Interfaces;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Interfaces.Window;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Initializers.WindowSettings.Models;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions;
using SullyTech.Wpf.Windows.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.MethodParameters.NavigateToOptions.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class SignInCommand : AsyncCommand<ISignInViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    private readonly IDialogWindowService _dialogWindowService;


    public SignInCommand(SignInViewModel callerViewModel, IChatHub chatHub, IToastNotification toastNotification,
        INavigationWindowService navigationWindowService, IDialogWindowService dialogWindowService) : base(callerViewModel)
    {
        _chatHub = chatHub;
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;
        _dialogWindowService = dialogWindowService;
    }

    public override async Task ExecuteAsync()
    {
        IDialogWindowShowOptions windowShowOptions = new DialogWindowShowOptions<IMessageDialogWindow, IMessageDialogWindowViewModel, IMessageDialogWindowSettingsViewModel>
        {
            WindowSettingsViewModelInitializerModel = new MessageDialogWindowSettingsViewModelInitializerModel
            {
                Title = "Test"
            }
        };

        IPresenterLoadOptions presenterLoadOptions = new PresenterLoadOptions<IMessageDialogViewModel, IMessageDialogDataViewModel>
        {
            PresenterViewModelInitializerModel = new MessageDialogViewModelInitializerModel
            {
                IconType = IconType.Information,
                ButtonType = ButtonType.OkCancel
            },
            PresenterDataViewModelInitializerModel = new MessageDialogDataViewModelInitializerModel
            {
                Message = "Test message"
            }
        };

        var test = await _dialogWindowService.ShowDialogAsync<IMessageDialogResult>(windowShowOptions, presenterLoadOptions);

        if (_chatHub.IsConnected == false)
        {
            await ShowChatServerIsNotAvailableToastMessage();
            return;
        }

        await SignInAsync();

        INavigationWindow presenterWindow = await GetPresenterWindow();

        await NavigateToChatView(presenterWindow);

        await WindowReSize(presenterWindow);
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

    private async Task WindowReSize(INavigationWindow presenterWindow)
    {
        await _navigationWindowService.SetWindowWidthAsync(presenterWindow, 1000);
        await _navigationWindowService.SetWindowHeightAsync(presenterWindow, 250);
    }
}