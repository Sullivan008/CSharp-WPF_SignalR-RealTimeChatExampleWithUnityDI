using System.Windows.Input;
using App.Client.SignalR.Hubs.Chat.Interfaces;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Commands.Window.Closing;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Commands.Window.Loaded;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Commands.Window.OnConnectionLost;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;
using App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Window;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Services.Navigation.Interfaces;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace App.Client.Wpf.Windows.Main.Window.ViewModels.Window;

public sealed class MainWindowViewModel : StandardWindowViewModel<IMainWindowSettingsViewModel>, IMainWindowViewModel
{
    private readonly IToastNotification _toastNotification;

    private readonly INavigationService _navigationService;


    private readonly IChatHub _chatHub;

    public MainWindowViewModel(IMainWindowSettingsViewModel settings, IToastNotification toastNotification, IWindowDestroyerService windowDestroyerService,
        INavigationService navigationService, IChatHub chatHub) : base(settings)
    {
        _toastNotification = toastNotification;
        _navigationService = navigationService;

        _chatHub = chatHub;

        LoadedCommand = new LoadedCommand(this);
        ClosingCommand = new ClosingCommand(this, windowDestroyerService);
    }

    private ICommand? _onConnectionLostCommand;
    public ICommand OnConnectionLostCommand =>
        _onConnectionLostCommand ??= new OnConnectionLostCommand(this, _toastNotification, _navigationService);

    public override async Task OnBeforeLoadAsync()
    {
        _chatHub.ConnectionLostAsync += OnConnectionLost;

        await Task.CompletedTask;
    }

    public override async Task OnDestroyAsync()
    {
        _chatHub.ConnectionLostAsync -= OnConnectionLost;

        await Task.CompletedTask;
    }

    private async Task OnConnectionLost(Exception? ex)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(async () =>
        {
            OnConnectionLostCommand.Execute(default);

            await Task.CompletedTask;
        });
    }
}
