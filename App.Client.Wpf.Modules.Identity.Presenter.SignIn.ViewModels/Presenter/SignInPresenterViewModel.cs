using System.Windows.Input;
using App.Client.SignalR.Hubs.Chat.Interfaces;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Commands.Presenter.Close;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Commands.Presenter.Loaded;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Commands.Presenter.SignIn;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.Presenter;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Services.Navigation.Interfaces;
using SullyTech.Wpf.Services.Window.Closer.Interfaces;

namespace App.Client.Wpf.Modules.Identity.Presenter.SignIn.ViewModels.Presenter;

public sealed class SignInPresenterViewModel : PresenterViewModel<ISignInPresenterDataViewModel>, ISignInPresenterViewModel
{
    private readonly IToastNotification _toastNotification;

    private readonly INavigationService _navigationService;

    private readonly IWindowCloserService _windowCloserService;


    private readonly IChatHub _chatHub;

    public SignInPresenterViewModel(ISignInPresenterDataViewModel viewData, INavigationService navigationService, IToastNotification toastNotification,
        IWindowCloserService windowCloserService, IChatHub chatHub) : base(viewData)
    {
        _toastNotification = toastNotification;
        _navigationService = navigationService;
        _windowCloserService = windowCloserService;

        _chatHub = chatHub;

        LoadedCommand = new LoadedCommand(this);
    }

    private ICommand? _closeCommand;
    public ICommand CloseCommand =>
        _closeCommand ??= new CloseCommand(this, _windowCloserService);


    private ICommand? _signInCommand;
    public ICommand SignInCommand =>
        _signInCommand ??= new SignInCommand(this, _toastNotification, _navigationService, _chatHub);
}