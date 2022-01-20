using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindowSettings;

namespace Application.Client.Windows.Implementations.Main.Window.ViewModels.MainWindow;

public class MainWindowSettingsViewModel : NavigationWindowSettingsViewModel
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