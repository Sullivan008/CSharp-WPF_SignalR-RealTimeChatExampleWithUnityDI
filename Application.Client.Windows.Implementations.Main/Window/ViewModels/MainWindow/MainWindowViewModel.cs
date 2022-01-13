using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;

public class MainWindowViewModel : NavigationWindowViewModelBase
{
    public MainWindowViewModel(IViewNavigationService viewNavigationService) : base(viewNavigationService)
    {
        //Test();
    }

    public void Test()
    {
        System.Diagnostics.Debug.WriteLine(((MainWindowSettingsViewModel)WindowSettings).Kefe);
    }
}