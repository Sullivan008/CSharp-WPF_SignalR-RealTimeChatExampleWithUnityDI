using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Commands.Window;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.Window;
using SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Windows.Navigation.ViewModels.NavigationWindow;

namespace SullyTech.App.Client.Wpf.Windows.Main.ViewModels.Window;

public sealed class MainWindowViewModel : NavigationWindowViewModel<IMainWindowSettingsViewModel>, IMainWindowViewModel
{
    public MainWindowViewModel(IMainWindowSettingsViewModel settings) : base(settings)
    {
        CloseWindowCommand = new CloseCommand(this);
    }
}