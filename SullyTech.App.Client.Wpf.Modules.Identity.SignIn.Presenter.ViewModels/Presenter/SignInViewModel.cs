using System.Windows.Input;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Commands.Presenter;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Presenter;

public sealed class SignInViewModel : PresenterViewModel<ISignInDataViewModel>, ISignInViewModel
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    public SignInViewModel(ISignInDataViewModel viewData, IChatHub chatHub, IToastNotification toastNotification,
        INavigationWindowService navigationWindowService) : base(viewData)
    {
        _chatHub = chatHub;
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;
    }

    private ICommand? _closeCommand;
    public ICommand CloseCommand => _closeCommand ??= new CloseCommand(this, _navigationWindowService);

    private ICommand? _signInCommand;
    public ICommand SignInCommand => _signInCommand ??= new SignInCommand(this, _chatHub, _toastNotification, _navigationWindowService);

    public override async Task OnInit()
    {
        INavigationWindow presenterWindow = await _navigationWindowService.GetWindowAsync(PresenterWindowId);

        await _navigationWindowService.SetWindowWidthAsync(presenterWindow, 450);
        await _navigationWindowService.SetWindowHeightAsync(presenterWindow, 750);
    }
}