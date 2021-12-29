using Application.Client.Common.Commands;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.Views.SignIn.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

namespace Application.Client.Windows.Main.Commands;

public class WindowLoadedCommand : AsyncCommandBase<MainWindowViewModel, EventArgs>
{
    private readonly IViewNavigationService<MainWindow> _viewNavigationService;

    public WindowLoadedCommand(MainWindowViewModel callerViewModel, IViewNavigationService<MainWindow> viewNavigationService) : base(callerViewModel)
    {
        _viewNavigationService = viewNavigationService;
    }

    public override async Task ExecuteAsync(EventArgs parameter)
    {
        _viewNavigationService.Navigate<SignInViewModel>();

        await Task.CompletedTask;
    }
}