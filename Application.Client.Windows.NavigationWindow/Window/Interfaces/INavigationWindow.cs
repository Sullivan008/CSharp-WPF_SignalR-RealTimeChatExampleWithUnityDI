using Application.Client.Windows.ApplicationWindow.Window.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Window.Interfaces;

public interface INavigationWindow : IApplicationWindow
{
    public object DataContext { get; set; }

    public void Show();
}