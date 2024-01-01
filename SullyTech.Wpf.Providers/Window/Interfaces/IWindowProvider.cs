namespace SullyTech.Wpf.Providers.Window.Interfaces;

public interface IWindowProvider
{
    public Controls.Window.Core.UserControls.Window GetWindow(string windowId);
}