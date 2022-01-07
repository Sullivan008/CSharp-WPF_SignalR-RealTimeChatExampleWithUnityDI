using Application.Client.Windows.Navigation.ViewNavigation.Initializers.ViewModelInitializers.NavigationWindowPageViewModelInitializer.Abstractions;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializers.Models;

public class SignInViewModelInitializerModel : BaseNavigationWindowPageViewModelInitializerModel
{
    public string Content { get; set; } = string.Empty;
}