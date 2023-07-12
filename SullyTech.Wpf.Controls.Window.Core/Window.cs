using SullyTech.Wpf.Controls.Window.Core.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Core;

public class Window : System.Windows.Window, IWindow
{
    public string Id { get; }

    public Window()
    {
        Id = Guid.NewGuid().ToString();
    }
}