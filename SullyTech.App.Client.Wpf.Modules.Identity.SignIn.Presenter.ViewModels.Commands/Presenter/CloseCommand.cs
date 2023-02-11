using System.Threading.Tasks;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Commands.Abstractions;
using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;
using SullyTech.Wpf.Windows.Navigation.Window.Services.NavigationWindow.Interfaces;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Commands.Presenter;

public sealed class CloseCommand : AsyncCommand<ISignInViewModel>
{
    private readonly INavigationWindowService _navigationWindowService;

    public CloseCommand(ISignInViewModel callerViewModel, INavigationWindowService navigationWindowService) : base(callerViewModel)
    {
        _navigationWindowService = navigationWindowService;
    }

    public override async Task ExecuteAsync()
    {
        INavigationWindow presenterWindow = await _navigationWindowService.GetWindowAsync(CallerViewModel.PresenterWindowId);

        await _navigationWindowService.CloseWindowAsync(presenterWindow);
    }
}