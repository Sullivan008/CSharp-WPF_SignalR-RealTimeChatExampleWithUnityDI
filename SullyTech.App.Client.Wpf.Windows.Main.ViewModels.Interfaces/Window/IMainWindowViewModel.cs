using System.Windows.Input;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.ViewModels.Interfaces.NavigationWindow;

namespace SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.Window;

public interface IMainWindowViewModel : INavigationWindowViewModel
{
    public new IMainWindowSettingsViewModel Settings { get; }

    public ICommand OnConnectionLostCommand { get; }
}