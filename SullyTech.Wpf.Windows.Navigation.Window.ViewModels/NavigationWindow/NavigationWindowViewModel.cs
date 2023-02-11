using SullyTech.Wpf.Windows.Core.Window.ViewModels.Window;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Interfaces.NavigationWindow;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Interfaces.NavigationWindowSettings;

namespace SullyTech.Wpf.Windows.Navigation.Window.ViewModels.NavigationWindow;

public class NavigationWindowViewModel<TINavigationWindowSettingsViewModel> : WindowViewModel<TINavigationWindowSettingsViewModel>, INavigationWindowViewModel
    where TINavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
{
    public NavigationWindowViewModel(TINavigationWindowSettingsViewModel settings) : base(settings)
    { }
}
