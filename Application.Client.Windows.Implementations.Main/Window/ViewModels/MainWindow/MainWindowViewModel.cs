using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;

public class MainWindowViewModel : NavigationWindowViewModel<MainWindowSettingsViewModel>
{
    public MainWindowViewModel(ICurrentNavigationWindowService currentNavigationWindowService) : base(currentNavigationWindowService)
    {
        Test();
    }

    public void Test()
    {
        System.Diagnostics.Debug.WriteLine(((MainWindowSettingsViewModel)WindowSettings).Kefe);
    }
}