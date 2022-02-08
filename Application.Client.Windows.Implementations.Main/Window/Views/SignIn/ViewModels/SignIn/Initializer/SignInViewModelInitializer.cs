using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer;

public class SignInViewModelInitializer : IContentPresenterViewModelInitializer<SignInViewModel, SignInViewModelInitializerModel>
{
    private readonly IContentPresenterViewDataViewModelInitializer<SignInViewDataViewModel, SignInViewDataViewModelInitializerModel> _contentPresenterViewDataViewModelInitializer;

    public SignInViewModelInitializer(IContentPresenterViewDataViewModelInitializer<SignInViewDataViewModel, SignInViewDataViewModelInitializerModel> contentPresenterViewDataViewModelInitializer)
    {
        _contentPresenterViewDataViewModelInitializer = contentPresenterViewDataViewModelInitializer;
    }

    public void Initialize(SignInViewModel contentPresenterViewModel, SignInViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        _contentPresenterViewDataViewModelInitializer.Initialize(contentPresenterViewModel.ViewData, contentPresenterViewModelInitializerModel.ViewDataInitializerModel);
    }
}