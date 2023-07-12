namespace SullyTech.Wpf.Controls.Window.Core.Interfaces;

public interface IWindow
{
    public string Id { get; }

    public object DataContext { get; set; }

    public void Close();
}