using Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.ViewModels.Abstractions;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;

public class MainWindowSettingsViewModel : NavigationWindowSettingsViewModelBase
{
    private string _kefe;

    public string Kefe
    {
        get => _kefe;
        set
        {
            _kefe = value;
            OnPropertyChanged();
        }
    }
}