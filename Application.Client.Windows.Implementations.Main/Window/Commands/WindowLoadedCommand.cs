using Application.Client.Common.Commands;
using Application.Client.Windows.Implementations.Main.Window.ViewModels;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Commands;

internal class WindowLoadedCommand : AsyncCommandBase<MainWindowViewModel, EventArgs>
{
    private readonly IViewNavigationService<MainWindow> _viewNavigationService;

    public WindowLoadedCommand(MainWindowViewModel callerViewModel, IViewNavigationService<MainWindow> viewNavigationService) : base(callerViewModel)
    {
        _viewNavigationService = viewNavigationService;
    }

    public override async Task ExecuteAsync(EventArgs parameter)
    {
        _viewNavigationService.Navigate<SignInViewModel, SignInViewModelInitializerModel>(() => new SignInViewModelInitializerModel { Content = "test content" });

        await Task.CompletedTask;
    }
}