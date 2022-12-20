using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow.Commands;
using Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindowSettings;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindow;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window.ViewModels.MainWindow;

public class MainWindowViewModel : NavigationWindowViewModel<IMainWindowSettingsViewModel>, IMainWindowViewModel
{
    public MainWindowViewModel(IMainWindowSettingsViewModel settings) : base(settings)
    {
        CloseWindowCommand = new CloseCommand(this);
    }
}

public interface IMainWindowViewModel : INavigationWindowViewModel
{
    public new IMainWindowSettingsViewModel Settings { get; }

}