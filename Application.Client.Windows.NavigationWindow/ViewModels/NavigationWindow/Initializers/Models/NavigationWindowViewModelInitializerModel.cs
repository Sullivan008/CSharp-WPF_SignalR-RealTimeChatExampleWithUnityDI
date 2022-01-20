using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Initializers.Abstractions;

namespace Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models;

public class NavigationWindowViewModelInitializerModel<TNavigationWindowSettingsViewModelInitializerModel> : 
                ApplicationWindowViewModelInitializerModel<TNavigationWindowSettingsViewModelInitializerModel>, INavigationWindowViewModelInitializerModel 
                    where TNavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{ }