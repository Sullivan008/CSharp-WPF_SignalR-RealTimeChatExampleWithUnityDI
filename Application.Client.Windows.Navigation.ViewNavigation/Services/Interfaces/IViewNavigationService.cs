using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Windows.Navigation.ViewNavigation.Initializers.ViewModelInitializers.NavigationWindowPageViewModelInitializer.Abstractions;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.Interfaces;

public interface IViewNavigationService<TNavigationWindow> where TNavigationWindow : NavigationWindow
{
    public void Navigate<TPageViewModelType>() where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow>;

    public void Navigate<TPageViewModelType, TPageViewModelInitializer>(Func<TPageViewModelInitializer> pageViewModelInitializer) where TPageViewModelType : NavigationWindowPageViewModelBase<TNavigationWindow>
                                                                                                                                  where TPageViewModelInitializer : BaseNavigationWindowPageViewModelInitializerModel;
}