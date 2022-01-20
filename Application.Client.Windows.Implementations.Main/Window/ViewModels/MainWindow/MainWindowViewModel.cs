using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;

public class MainWindowViewModel : NavigationWindowViewModel<MainWindowSettingsViewModel>
{
    public MainWindowViewModel(IPageViewNavigationService viewNavigationService) : base(viewNavigationService)
    {
        Test();
    }

    public void Test()
    {
        System.Diagnostics.Debug.WriteLine(((MainWindowSettingsViewModel)WindowSettings).Kefe);
    }
}