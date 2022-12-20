using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindowSettings;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindowSettings;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings;

public class MainWindowSettingsViewModel : NavigationWindowSettingsViewModel, IMainWindowSettingsViewModel
{ }

public interface IMainWindowSettingsViewModel : INavigationWindowSettingsViewModel
{ }