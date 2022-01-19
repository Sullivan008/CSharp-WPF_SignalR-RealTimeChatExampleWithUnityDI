using Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer.Models;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow.Initializers.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindowSettings.Initializers.Interfaces;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow.Initializer;

public class MainWindowViewModelInitializer : INavigationWindowViewModelInitializer<MainWindowViewModel, MainWindowViewModelInitializerModel>
{
    private readonly INavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel> _navigationWindowSettingsViewModelInitializer;

    public MainWindowViewModelInitializer(INavigationWindowSettingsViewModelInitializer<MainWindowSettingsViewModel, MainWindowSettingsViewModelInitializerModel> navigationWindowSettingsViewModelInitializer)
    {
        _navigationWindowSettingsViewModelInitializer = navigationWindowSettingsViewModelInitializer;
    }

    public void Initialize(MainWindowViewModel navigationWindowViewModel, MainWindowViewModelInitializerModel navigationWindowViewModelInitializerModel)
    {
        _navigationWindowSettingsViewModelInitializer.Initialize(navigationWindowViewModel.WindowSettings, navigationWindowViewModelInitializerModel.WindowSettings);
    }
}