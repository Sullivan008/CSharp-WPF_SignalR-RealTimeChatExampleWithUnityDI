namespace SullyTech.Wpf.Windows.Core.Window.Interfaces;

public interface IWindow
{
    public object DataContext { get; set; }

    public void Close();
}