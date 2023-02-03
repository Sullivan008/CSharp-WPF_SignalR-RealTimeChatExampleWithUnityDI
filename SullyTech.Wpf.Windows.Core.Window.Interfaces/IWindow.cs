namespace SullyTech.Wpf.Windows.Core.Window.Interfaces;

public interface IWindow
{
    public string Id { get; }

    public object DataContext { get; set; }

    public void Close();
}