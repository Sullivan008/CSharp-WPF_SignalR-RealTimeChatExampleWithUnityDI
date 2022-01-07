using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer;

public class SignInViewModelInitializer : IPageViewModelInitializer<MainWindow, SignInViewModel, SignInViewModelInitializerModel>
{
    public void Initialize(SignInViewModel navigationWindowPageViewModel, SignInViewModelInitializerModel navigationWindowPageViewModelInitializerModel)
    {
        navigationWindowPageViewModel.Content = navigationWindowPageViewModelInitializerModel.Content;
    }
}