namespace Application.Client.Windows.Navigation.ViewNavigation.Windows.NavigationWindow.Interfaces;

public interface INavigationWindow
{
    public object DataContext { get; set; }

    public void Show();
}