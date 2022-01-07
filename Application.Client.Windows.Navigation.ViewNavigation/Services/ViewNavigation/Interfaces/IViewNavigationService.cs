using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;

public interface IViewNavigationService<TNavigationWindow> where TNavigationWindow : NavigationWindow
{
    public void Navigate<TPageViewModel>() where TPageViewModel : PageViewModelBase<TNavigationWindow>;

    public void Navigate<TPageViewModel, TPageViewModelInitializer>(Func<TPageViewModelInitializer> pageViewModelInitializerFactory) where TPageViewModel : PageViewModelBase<TNavigationWindow>
                                                                                                                                     where TPageViewModelInitializer : BasePageViewModelInitializerModel;
}