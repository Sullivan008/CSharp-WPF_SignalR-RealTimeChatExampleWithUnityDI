using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Commands;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindow;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow;

public class MainWindowViewModel : NavigationWindowViewModel<MainWindowSettingsViewModel>
{
    public MainWindowViewModel(MainWindowSettingsViewModel settings) : base(settings)
    {
        CloseWindowCommand = new CloseCommand(this);
    }
}