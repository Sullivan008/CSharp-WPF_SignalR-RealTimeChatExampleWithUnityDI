using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Interfaces;

public interface INavigationWindowViewModel : IApplicationWindowViewModel
{
    public IPageViewViewModel CurrentPage { get; set; }

    public IViewNavigationService ViewNavigationService { get; }
}