namespace Application.Client.Windows.ApplicationWindow.Window.Interfaces;

public interface IApplicationWindow
{
    public object DataContext { get; set; }

    public void Show();
}