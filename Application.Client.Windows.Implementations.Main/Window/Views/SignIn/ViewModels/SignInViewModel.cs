using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Application.Client.Windows.Services.Interfaces;
using System.Windows.Input;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels;

internal class SignInViewModel : NavigationWindowPageViewModelBase<MainWindow>
{
    private readonly IApplicationWindowService _applicationWindowService;

    public SignInViewModel(IViewNavigationService<MainWindow> viewNavigationService, IApplicationWindowService applicationWindowService) : base(viewNavigationService)
    {
        _applicationWindowService = applicationWindowService;
    }

    private ICommand? _openTestWindowCommand;
    public ICommand OpenTestWindowCommand => _openTestWindowCommand ??= new OpenTestWindowCommand(this, _applicationWindowService);
}