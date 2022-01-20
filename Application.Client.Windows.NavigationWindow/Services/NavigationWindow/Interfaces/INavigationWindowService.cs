using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Interfaces;

public interface INavigationWindowService
{
    public Task ShowAsync(INavigationWindowOptionsModel navigationWindowOptions, IPageViewNavigationOptions pageViewNavigationOptions);
}