using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;

public interface IPageViewNavigationService
{
    public void Navigate(IPageViewNavigationOptions pageViewNavigationOptions);
}