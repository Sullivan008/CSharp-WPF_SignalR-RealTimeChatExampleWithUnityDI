using System.Windows.Input;
using Application.Client.Windows.Main.Views.SignIn.Commands;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;
using Application.Client.Windows.Services.Interfaces;

namespace Application.Client.Windows.Main.Views.SignIn.ViewModels;

public class SignInViewModel : NavigationWindowPageViewModelBase<MainWindow>
{
    private readonly IApplicationWindowService _dialogService;

    public SignInViewModel(IViewNavigationService<MainWindow> viewNavigationService, IApplicationWindowService dialogService) : base(viewNavigationService)
    {
        _dialogService = dialogService;
    }

    private ICommand? _openTestDialogCommand;
    public ICommand OpenTestDialogCommand => _openTestDialogCommand ??= new OpenTestWindowCommand(this, _dialogService);
}