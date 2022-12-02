using SullyTech.Wpf.Windows.Core.Presenter.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class CloseCommand : AsyncCommand<SignInViewModel>
{
    private readonly ICurrentNavigationWindowService _currentWindowService;

    public CloseCommand(SignInViewModel callerViewModel, ICurrentNavigationWindowService currentWindowService) : base(callerViewModel)
    {
        _currentWindowService = currentWindowService;
    }

    public override async Task ExecuteAsync()
    {
        await _currentWindowService.CloseWindowAsync();
    }
}