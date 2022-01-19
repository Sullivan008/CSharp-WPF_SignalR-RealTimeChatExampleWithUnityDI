using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.ViewModels.NavigationWindow;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;

public class MainWindowViewModel : NavigationWindowViewModel<MainWindowSettingsViewModel>
{
    public MainWindowViewModel(IViewNavigationService viewNavigationService) : base(viewNavigationService)
    {
        Test();
    }

    public void Test()
    {
        System.Diagnostics.Debug.WriteLine(((MainWindowSettingsViewModel)WindowSettings).Kefe);
    }
}