using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.Initializer.Models;

public class SignInViewModelInitializerModel : BasePageViewModelInitializerModel
{
    public string Content { get; set; } = string.Empty;
}