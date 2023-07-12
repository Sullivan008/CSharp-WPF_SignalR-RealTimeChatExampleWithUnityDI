using SullyTech.Wpf.Controls.Window.Core.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Providers.Window.Interfaces;

public interface IWindowProvider
{
    public Task<IWindow> GetWindowAsync(string windowId);
}