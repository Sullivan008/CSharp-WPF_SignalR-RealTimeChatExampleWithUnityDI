using SullyTech.App.Client.Wpf.Windows.Main.Interfaces.Window;
using SullyTech.Wpf.Windows.Navigation.Window;

namespace SullyTech.App.Client.Wpf.Windows.Main;

public sealed partial class MainWindow : NavigationWindow, IMainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
}