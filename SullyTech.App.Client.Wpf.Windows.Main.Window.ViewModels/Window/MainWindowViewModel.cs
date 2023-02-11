using System.Windows.Input;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Interfaces;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Commands.Window;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.NavigationWindow;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Window;

public sealed class MainWindowViewModel : NavigationWindowViewModel<IMainWindowSettingsViewModel>, IMainWindowViewModel
{
    private readonly IChatHub _chatHub;

    private readonly IToastNotification _toastNotification;

    private readonly INavigationWindowService _navigationWindowService;

    public MainWindowViewModel(IMainWindowSettingsViewModel settings, IChatHub chatHub, 
        IToastNotification toastNotification, INavigationWindowService navigationWindowService) : base(settings)
    {
        _chatHub = chatHub;
        _toastNotification = toastNotification;
        _navigationWindowService = navigationWindowService;

        CloseWindowCommand = new CloseCommand(this);
    }

    private ICommand? _onConnectionLostCommand;
    public ICommand OnConnectionLostCommand => _onConnectionLostCommand ??=
        new OnConnectionLostCommand(this, _toastNotification, _navigationWindowService);

    public override async Task OnInit()
    {
        _chatHub.ConnectionLost += OnConnectionLost;

        await Task.CompletedTask;
    }

    public override async Task OnDestroy()
    {
        _chatHub.ConnectionLost -= OnConnectionLost;

        await Task.CompletedTask;
    }

    private async Task OnConnectionLost(Exception? ex)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(async () =>
        {
            OnConnectionLostCommand.Execute(ex);

            await Task.CompletedTask;
        });
    }
}
