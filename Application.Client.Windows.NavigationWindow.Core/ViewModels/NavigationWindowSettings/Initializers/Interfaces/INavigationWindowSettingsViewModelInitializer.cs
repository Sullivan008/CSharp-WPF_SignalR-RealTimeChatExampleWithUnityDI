using Application.Client.Windows.Core.ViewModels.WindowSettings.Initializer.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Initializers.Interfaces;

public interface INavigationWindowSettingsViewModelInitializer<in TNavigationWindowSettingsViewModel, in TNavigationWindowSettingsViewModelInitializerModel> : 
    IWindowSettingsViewModelInitializer<TNavigationWindowSettingsViewModel, TNavigationWindowSettingsViewModelInitializerModel> 
        where TNavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
        where TNavigationWindowSettingsViewModelInitializerModel : INavigationWindowSettingsViewModelInitializerModel
{ }