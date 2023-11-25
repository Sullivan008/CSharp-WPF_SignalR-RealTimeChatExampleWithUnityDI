using SullyTech.Wpf.Controls.Window.Core.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Core;

public class Window : System.Windows.Window, IWindow
{
    private string? _id;
    public string Id
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_id, nameof(Id));

            return _id!;
        }

        set
        {
            Guard.Guard.ThrowIfNullOrWhitespace(value, nameof(value));

            _id = value!;
        }
    }
}