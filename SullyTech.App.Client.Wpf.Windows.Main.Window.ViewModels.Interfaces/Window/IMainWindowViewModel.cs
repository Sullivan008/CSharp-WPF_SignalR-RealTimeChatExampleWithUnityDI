using System.Windows.Input;
using SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.Window.ViewModels.Interfaces.NavigationWindow;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window.ViewModels.Interfaces.Window;

public interface IMainWindowViewModel : INavigationWindowViewModel
{
    public new IMainWindowSettingsViewModel Settings { get; }

    public ICommand OnConnectionLostCommand { get; }
}