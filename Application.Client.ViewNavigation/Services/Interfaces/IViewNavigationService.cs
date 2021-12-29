using Application.Client.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Navigation.ViewNavigation.Abstractions.Windows;

namespace Application.Client.Navigation.ViewNavigation.Services.Interfaces;

public interface IViewNavigationService<TNavigationWindow> where TNavigationWindow : NavigationWindow
{
    public void Navigate<TPageViewModelType>() where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow>;
}