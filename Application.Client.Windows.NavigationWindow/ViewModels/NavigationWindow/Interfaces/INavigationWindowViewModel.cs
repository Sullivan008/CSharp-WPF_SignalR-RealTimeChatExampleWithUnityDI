using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;

public interface INavigationWindowViewModel : IApplicationWindowViewModel
{
    public IPageViewViewModel CurrentPage { get; set; }

    public IPageViewNavigationService PageViewNavigationService { get; }
}