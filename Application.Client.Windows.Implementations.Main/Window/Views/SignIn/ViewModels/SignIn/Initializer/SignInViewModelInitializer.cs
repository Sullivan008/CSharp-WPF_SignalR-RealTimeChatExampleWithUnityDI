using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Initializers.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageViewData.Initializers.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer;

public class SignInViewModelInitializer : IPageViewViewModelInitializer<SignInViewModel, SignInViewModelInitializerModel>
{
    private readonly IPageViewDataViewModelInitializer<SignInViewDataViewModel, SignInViewDataViewModelInitializerModel> _pageViewDataViewModelInitializer;

    public SignInViewModelInitializer(IPageViewDataViewModelInitializer<SignInViewDataViewModel, SignInViewDataViewModelInitializerModel> pageViewDataViewModelInitializer)
    {
        _pageViewDataViewModelInitializer = pageViewDataViewModelInitializer;
    }

    public void Initialize(SignInViewModel navigationWindowPageViewModel, SignInViewModelInitializerModel navigationWindowPageViewModelInitializerModel)
    {
        _pageViewDataViewModelInitializer.Initialize(navigationWindowPageViewModel.ViewData, navigationWindowPageViewModelInitializerModel.ViewDataInitializerModel);
    }
}