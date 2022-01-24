using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Models;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models;

public class NavigationWindowViewModelInitializerModel<TNavigationWindowSettingsViewModelInitializerModel> : 
                ApplicationWindowViewModelInitializerModel<TNavigationWindowSettingsViewModelInitializerModel>, INavigationWindowViewModelInitializerModel 
                    where TNavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{ }