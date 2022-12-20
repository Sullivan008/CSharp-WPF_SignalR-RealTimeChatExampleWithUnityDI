using SullyTech.Wpf.Windows.Core.ViewModels.Window;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindowSettings;

namespace SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindow;

public class NavigationWindowViewModel<TINavigationWindowSettingsViewModel> : WindowViewModel<TINavigationWindowSettingsViewModel>, INavigationWindowViewModel
    where TINavigationWindowSettingsViewModel : INavigationWindowSettingsViewModel
{
    public NavigationWindowViewModel(TINavigationWindowSettingsViewModel settings) : base(settings)
    { }
}
