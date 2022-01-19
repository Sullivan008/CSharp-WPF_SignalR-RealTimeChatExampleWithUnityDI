using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.Windows.ApplicationWindow.ViewModels.Initializers.Abstractions;

namespace Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Models;

public class NavigationWindowViewModelInitializerModel<TNavigationWindowSettingsViewModelInitializerModel> : 
                ApplicationWindowViewModelInitializerModel<TNavigationWindowSettingsViewModelInitializerModel>, INavigationWindowViewModelInitializerModel 
                    where TNavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{ }