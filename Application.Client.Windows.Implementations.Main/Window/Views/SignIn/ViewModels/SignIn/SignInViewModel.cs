using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : ContentPresenterViewModel<SignInViewDataViewModel>
{
    public SignInViewModel(ICurrentNavigationWindowService currentNavigationWindowService) : base(currentNavigationWindowService)
    { }
}