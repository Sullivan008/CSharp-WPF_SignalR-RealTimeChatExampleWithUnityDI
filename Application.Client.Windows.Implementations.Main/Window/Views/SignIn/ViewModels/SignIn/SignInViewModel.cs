using System.Windows.Input;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : ContentPresenterViewModel<SignInViewDataViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotificationService _toastNotificationService;

    public SignInViewModel(SignInViewDataViewModel viewData, ICurrentNavigationWindowService currentWindowService,
        IChatHub chatHub, IToastNotificationService toastNotificationService) : base(viewData, currentWindowService)
    {
        _chatHub = chatHub;
        _toastNotificationService = toastNotificationService;
    }

    private ICommand? _closeCommand;
    public ICommand CloseCommand => _closeCommand ??= new CloseCommand(this, (ICurrentNavigationWindowService)CurrentWindowService);

    private ICommand? _signInCommand;
    public ICommand SignInCommand => _signInCommand ??= new SignInCommand(this, _chatHub, _toastNotificationService);
}