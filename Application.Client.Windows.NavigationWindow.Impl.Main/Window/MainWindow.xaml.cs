using SullyTech.Wpf.Windows.Navigation.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Impl.Main.Window;

public partial class MainWindow : SullyTech.Wpf.Windows.Navigation.Window.NavigationWindow, IMainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
}

public interface IMainWindow : INavigationWindow
{ }