using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.Abstractions.Options;

namespace Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models;

public class NavigationWindowOptionsModel<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel> : 
    ApplicationWindowOptions<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel>, INavigationWindowOptionsModel
        where TNavigationWindow : INavigationWindow
        where TNavigationWindowViewModel : INavigationWindowViewModel
        where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{ }
