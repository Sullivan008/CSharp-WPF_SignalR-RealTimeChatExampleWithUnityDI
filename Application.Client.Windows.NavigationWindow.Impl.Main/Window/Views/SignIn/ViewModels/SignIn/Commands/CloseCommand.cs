using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Services.NavigationWindow.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;

internal class CloseCommand : AsyncCommand<SignInViewModel>
{
    private readonly INavigationWindowService _navigationWindowService;

    public CloseCommand(SignInViewModel callerViewModel, INavigationWindowService navigationWindowService) : base(callerViewModel)
    {
        _navigationWindowService = navigationWindowService;
    }

    public override async Task ExecuteAsync()
    {
        INavigationWindow presenterWindow = await _navigationWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);

        await _navigationWindowService.CloseWindowAsync(presenterWindow);
    }
}