using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Interfaces;

public interface IPageViewModelInitializer<TNavigationWindow, in TPageViewModel, in TPageViewModelInitializerModel> where TNavigationWindow : NavigationWindow
                                                                                                                    where TPageViewModel : PageViewModelBase<TNavigationWindow>
                                                                                                                    where TPageViewModelInitializerModel : BasePageViewModelInitializerModel
{
    public void Initialize(TPageViewModel pageViewModel, TPageViewModelInitializerModel pageViewModelInitializerModel);
}