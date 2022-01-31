using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;

public interface INavigationWindowViewModel : IApplicationWindowViewModel
{
    public IPageViewViewModel CurrentPage { get; set; }

    internal ICurrentNavigationWindowService CurrentNavigationWindowService { get; }
}