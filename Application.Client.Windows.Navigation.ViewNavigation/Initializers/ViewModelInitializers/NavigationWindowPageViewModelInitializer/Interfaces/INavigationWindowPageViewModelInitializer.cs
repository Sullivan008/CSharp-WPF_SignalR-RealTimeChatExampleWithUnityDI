using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Abstractions.Windows;
using Application.Client.Windows.Navigation.ViewNavigation.Initializers.ViewModelInitializers.NavigationWindowPageViewModelInitializer.Abstractions;

namespace Application.Client.Windows.Navigation.ViewNavigation.Initializers.ViewModelInitializers.NavigationWindowPageViewModelInitializer.Interfaces;

public interface INavigationWindowPageViewModelInitializer<TNavigationWindow, in TNavigationWindowPageViewModel, in TNavigationWindowPageViewModelInitializerModel> where TNavigationWindow : NavigationWindow
                                                                                                                                                                    where TNavigationWindowPageViewModel : NavigationWindowPageViewModelBase<TNavigationWindow>
                                                                                                                                                                    where TNavigationWindowPageViewModelInitializerModel : BaseNavigationWindowPageViewModelInitializerModel
{
    public void Initialize(TNavigationWindowPageViewModel navigationWindowPageViewModel, TNavigationWindowPageViewModelInitializerModel navigationWindowPageViewModelInitializerModel);
}