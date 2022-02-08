using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;

public class SignInViewDataViewModelInitializer : IContentPresenterViewDataViewModelInitializer<SignInViewDataViewModel, SignInViewDataViewModelInitializerModel>
{
    public void Initialize(SignInViewDataViewModel pageViewDataViewModel, SignInViewDataViewModelInitializerModel pageViewDataViewModelInitializerModel)
    {
        pageViewDataViewModel.Content = pageViewDataViewModelInitializerModel.Content;
    }
}