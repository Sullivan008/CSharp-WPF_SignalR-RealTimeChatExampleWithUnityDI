using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Commands;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow;

public class MainWindowViewModel : NavigationWindowViewModel<MainWindowSettingsViewModel>
{
    public MainWindowViewModel()
    {
        CloseWindowCommand = new CloseWindowCommand(this);
    }
}