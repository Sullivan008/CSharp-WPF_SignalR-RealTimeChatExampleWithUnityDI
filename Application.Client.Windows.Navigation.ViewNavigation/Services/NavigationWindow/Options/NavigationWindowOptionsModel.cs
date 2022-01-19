using Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Options.Models;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.Abstractions.Options;

namespace Application.Client.Windows.Navigation.ViewNavigation.Services.NavigationWindow.Options;

public class NavigationWindowOptionsModel<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel> : 
    ApplicationWindowOptions<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel>, INavigationWindowOptionsModel
        where TNavigationWindow : INavigationWindow
        where TNavigationWindowViewModel : INavigationWindowViewModel
        where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{ }
