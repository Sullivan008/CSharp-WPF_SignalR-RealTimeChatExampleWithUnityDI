using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData.Initializer.Models;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer;

public class SignInViewModelInitializer : IContentPresenterViewModelInitializer<SignInViewModel, SignInViewModelInitializerModel>
{
    private readonly IContentPresenterViewDataViewModelInitializer<SignInViewDataViewModel, SignInViewDataViewModelInitializerModel> _viewDataInitializer;

    public SignInViewModelInitializer(IContentPresenterViewDataViewModelInitializer<SignInViewDataViewModel, SignInViewDataViewModelInitializerModel> viewDataInitializer)
    {
        _viewDataInitializer = viewDataInitializer;
    }

    public void Initialize(SignInViewModel contentPresenterViewModel, SignInViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        _viewDataInitializer.Initialize(contentPresenterViewModel.ViewData, contentPresenterViewModelInitializerModel.ViewDataInitializerModel);
    }
}