namespace SullyTech.Wpf.Controls.Window.Core.UserControls;

public class Window : System.Windows.Window
{
    private string? _id;
    public string Id
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_id);

            return _id!;
        }

        set
        {
            Guard.Guard.ThrowIfNullOrWhitespace(value);

            _id = value;
        }
    }
}