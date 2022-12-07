using System.Windows.Input;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : PresenterViewModel<SignInViewDataViewModel>
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly ICurrentNavigationWindowService _currentNavigationWindowService;

    public SignInViewModel(SignInViewDataViewModel viewData, ICurrentNavigationWindowService currentWindowService,
        IChatHub chatHub, IToastNotification toastNotification) : base(viewData)
    {
        _chatHub = chatHub;
        _toastNotification = toastNotification;
        _currentNavigationWindowService = currentWindowService;
    }

    private ICommand? _closeCommand;
    public ICommand CloseCommand => _closeCommand ??= new CloseCommand(this, _currentNavigationWindowService);

    private ICommand? _signInCommand;
    public ICommand SignInCommand => _signInCommand ??= new SignInCommand(this, _chatHub, _toastNotification, _currentNavigationWindowService);
}