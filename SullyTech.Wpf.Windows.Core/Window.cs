using SullyTech.Wpf.Windows.Core.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Core.Window;

public class Window : System.Windows.Window, IWindow
{
    public string Id { get; }

    public Window()
    {
        Id = Guid.NewGuid().ToString();
    }
}