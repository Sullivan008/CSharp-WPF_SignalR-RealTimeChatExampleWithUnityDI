using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer;

public class SignInViewModelInitializer : IPageViewModelInitializer<SignInViewModel, SignInViewModelInitializerModel>
{
    public void Initialize(SignInViewModel navigationWindowPageViewModel, SignInViewModelInitializerModel navigationWindowPageViewModelInitializerModel)
    {
        InitializeViewData((SignInViewDataViewModel)navigationWindowPageViewModel.ViewData,
                           (SignInViewDataViewModelInitializerModel)navigationWindowPageViewModelInitializerModel.ViewDataInitializerModel);
    }

    private void InitializeViewData(SignInViewDataViewModel viewData, SignInViewDataViewModelInitializerModel viewDataInitializerModel)
    {
        viewData.Content = viewDataInitializerModel.Content;
    }
}