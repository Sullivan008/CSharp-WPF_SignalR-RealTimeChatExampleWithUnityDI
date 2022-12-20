using System.Windows.Input;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn;

public sealed class SignInViewModel : PresenterViewModel<ISignInDataViewModel>, ISignInViewModel
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    private readonly IDialogWindowService _dialogWindowService;

    public SignInViewModel(ISignInDataViewModel viewData, IChatHub chatHub, IToastNotification toastNotification,
        INavigationWindowService navigationWindowService, IDialogWindowService dialogWindowService) : base(viewData)
    {
        _chatHub = chatHub;
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;
        _dialogWindowService = dialogWindowService;
    }

    IPresenterDataViewModel IPresenterViewModel.Data => Data;

    private ICommand? _closeCommand;
    public ICommand CloseCommand => _closeCommand ??= new CloseCommand(this, _navigationWindowService);

    private ICommand? _signInCommand;
    public ICommand SignInCommand => _signInCommand ??= new SignInCommand(this, _chatHub, _toastNotification, _navigationWindowService, _dialogWindowService);
}

public interface ISignInViewModel : IPresenterViewModel
{
    public new ISignInDataViewModel Data { get; }
}