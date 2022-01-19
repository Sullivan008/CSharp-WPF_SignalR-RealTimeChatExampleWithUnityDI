using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Options.Models;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Interfaces;

public interface INavigationWindowService
{
    public Task ShowAsync<TPageViewViewModel>(INavigationWindowOptionsModel navigationWindowOptions) where TPageViewViewModel : IPageViewViewModel;
}