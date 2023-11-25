namespace SullyTech.Wpf.Controls.Window.Core.Interfaces;

public interface IWindow
{
    public string Id { get; set; }

    public object DataContext { get; set; }

    public void Close();
}