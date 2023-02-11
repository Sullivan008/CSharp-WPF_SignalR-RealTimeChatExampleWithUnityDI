using SullyTech.App.Client.Wpf.Windows.Main.Window.Interfaces;

namespace SullyTech.App.Client.Wpf.Windows.Main.Window;

public sealed partial class MainWindow : SullyTech.Wpf.Windows.Navigation.Window.NavigationWindow, IMainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
}