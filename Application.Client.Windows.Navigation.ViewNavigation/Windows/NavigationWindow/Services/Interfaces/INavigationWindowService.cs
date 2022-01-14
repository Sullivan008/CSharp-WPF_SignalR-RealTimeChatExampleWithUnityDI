using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Interfaces.Markers;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Abstractions.Options;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Initializers.Abstractions.Models;

namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Services.Interfaces;

public interface INavigationWindowService
{
    public Task ShowAsync<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel, TPageViewModel>(
        NavigationWindowOptions<TNavigationWindowViewModelInitializerModel> navigationWindowOptions) where TNavigationWindow : Abstractions.Window.NavigationWindow
                                                                                                     where TNavigationWindowViewModel : NavigationWindowViewModelBase
                                                                                                     where TNavigationWindowViewModelInitializerModel : BaseNavigationWindowViewModelInitializerModel
                                                                                                     where TPageViewModel : IPageViewModel;

    public Task ShowAsync<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel, TPageViewModel, TPageViewModelInitializer>(
        NavigationWindowOptions<TNavigationWindowViewModelInitializerModel, TPageViewModelInitializer> navigationWindowOptions) where TNavigationWindow : Abstractions.Window.NavigationWindow
                                                                                                                                where TNavigationWindowViewModel : NavigationWindowViewModelBase
                                                                                                                                where TNavigationWindowViewModelInitializerModel : BaseNavigationWindowViewModelInitializerModel
                                                                                                                                where TPageViewModel : IPageViewModel
                                                                                                                                where TPageViewModelInitializer : IPageViewModelInitializerModel;

}