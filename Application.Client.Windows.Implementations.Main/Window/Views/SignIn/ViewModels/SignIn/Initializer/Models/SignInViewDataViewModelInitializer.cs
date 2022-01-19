using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Initializers.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;

public class SignInViewDataViewModelInitializer : IPageViewDataViewModelInitializer<SignInViewDataViewModel, SignInViewDataViewModelInitializerModel>
{
    public void Initialize(SignInViewDataViewModel pageViewDataViewModel, SignInViewDataViewModelInitializerModel pageViewDataViewModelInitializerModel)
    {
        pageViewDataViewModel.Content = pageViewDataViewModelInitializerModel.Content;
    }
}