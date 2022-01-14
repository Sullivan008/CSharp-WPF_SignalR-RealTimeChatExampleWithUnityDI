using System.Windows.Input;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.Commands;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Services.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : PageViewModelBase<SignInViewDataViewModel>, IPageViewModel
{
    private readonly INavigationWindowService _navigationWindowService;

    public SignInViewModel(IViewNavigationService viewNavigationService, INavigationWindowService navigationWindowService) : base(viewNavigationService)
    {
        _navigationWindowService = navigationWindowService;
    }
    
    private ICommand? _openTestWindowCommand;
    public ICommand OpenTestWindowCommand => _openTestWindowCommand ??= new OpenTestWindowCommand(this, _navigationWindowService);
}