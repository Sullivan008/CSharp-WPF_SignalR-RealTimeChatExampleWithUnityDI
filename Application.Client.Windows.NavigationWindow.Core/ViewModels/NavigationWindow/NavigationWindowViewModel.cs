using Application.Client.Windows.Core.ViewModels.Window;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindowSettings.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow;

public class NavigationWindowViewModel<TNavigationWindowSettingsViewModel> : WindowViewModel<TNavigationWindowSettingsViewModel>, INavigationWindowViewModel
    where TNavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel, new()
{ }