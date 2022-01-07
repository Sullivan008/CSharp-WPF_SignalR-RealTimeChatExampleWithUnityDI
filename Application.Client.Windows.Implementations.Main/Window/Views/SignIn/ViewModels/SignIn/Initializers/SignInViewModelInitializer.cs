using Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializers.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Initializers.ViewModelInitializers.NavigationWindowPageViewModelInitializer.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializers;

public class SignInViewModelInitializer : INavigationWindowPageViewModelInitializer<MainWindow, SignInViewModel, SignInViewModelInitializerModel>
{
    public void Initialize(SignInViewModel navigationWindowPageViewModel, SignInViewModelInitializerModel navigationWindowPageViewModelInitializerModel)
    {
        navigationWindowPageViewModel.Content = navigationWindowPageViewModelInitializerModel.Content;
    }
}