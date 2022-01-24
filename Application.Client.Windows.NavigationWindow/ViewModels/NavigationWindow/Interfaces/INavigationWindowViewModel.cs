using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;

public interface INavigationWindowViewModel : IApplicationWindowViewModel
{
    public IPageViewViewModel CurrentPage { get; set; }

    public IPageViewNavigationService PageViewNavigationService { get; }
}