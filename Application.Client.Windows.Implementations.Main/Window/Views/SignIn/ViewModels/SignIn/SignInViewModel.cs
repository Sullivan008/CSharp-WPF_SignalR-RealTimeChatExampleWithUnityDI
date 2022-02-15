using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn;

public class SignInViewModel : ContentPresenterViewModel<SignInViewDataViewModel>
{
    public SignInViewModel(ICurrentWindowService currentWindowService, SignInViewDataViewModel viewData) : base(currentWindowService, viewData)
    { }
}