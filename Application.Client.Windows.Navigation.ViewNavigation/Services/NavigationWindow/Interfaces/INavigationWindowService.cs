using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Options.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Interfaces;

public interface INavigationWindowService
{
    public Task ShowAsync<TNavigationWindow, TPageViewViewModel>(INavigationWindowOptionsModel navigationWindowOptions) where TNavigationWindow : INavigationWindow
                                                                                                                        where TPageViewViewModel : IPageViewViewModel;
}