using System.Windows.Input;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Commands;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : ContentPresenterViewModel<SignInViewDataViewModel>
{
    public SignInViewModel(SignInViewDataViewModel viewData, ICurrentWindowService currentWindowService) : base(viewData, currentWindowService)
    { }

    private ICommand? _signInCommand;
    public ICommand SignInCommand => _signInCommand ??= new SignInCommand(this);
}