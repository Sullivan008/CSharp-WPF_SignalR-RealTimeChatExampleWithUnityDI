namespace Application.Client.Windows.NavigationWindow.Window.Interfaces;

public interface INavigationWindow
{
    public object DataContext { get; set; }

    public void Show();
}