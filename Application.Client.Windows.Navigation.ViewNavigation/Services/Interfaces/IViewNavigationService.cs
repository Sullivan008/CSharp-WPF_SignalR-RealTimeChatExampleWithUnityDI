using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.Windows;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

public interface IViewNavigationService<TNavigationWindow> where TNavigationWindow : NavigationWindow
{
    public void Navigate<TPageViewModelType>() where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow>;
}