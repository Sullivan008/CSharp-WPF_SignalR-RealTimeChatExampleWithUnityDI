using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;

public interface IPageViewNavigationService
{
    internal ICurrentNavigationWindowService CurrentNavigationWindowService { set; }

    internal void Navigate(IPageViewNavigationOptions pageViewNavigationOptions);
}