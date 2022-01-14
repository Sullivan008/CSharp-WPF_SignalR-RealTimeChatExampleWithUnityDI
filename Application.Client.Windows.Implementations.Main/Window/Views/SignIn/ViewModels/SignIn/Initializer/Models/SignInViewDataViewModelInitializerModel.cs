using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Abstractions;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;

public class SignInViewDataViewModelInitializerModel : PageViewDataViewModelInitializerModelBase
{
    public string Content { get; set; } = string.Empty;
}