using Application.Client.Windows.Core.ContentPresenter.Commands.Abstractions;
using Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class CloseCommand : AsyncContentPresenterCommand<SignInViewModel>
{
    private readonly ICurrentNavigationWindowService _currentWindowService;

    public CloseCommand(SignInViewModel callerViewModel, ICurrentNavigationWindowService currentWindowService) : base(callerViewModel)
    {
        _currentWindowService = currentWindowService;
    }

    public override async Task ExecuteAsync()
    {
        await _currentWindowService.CloseWindow();
    }
}