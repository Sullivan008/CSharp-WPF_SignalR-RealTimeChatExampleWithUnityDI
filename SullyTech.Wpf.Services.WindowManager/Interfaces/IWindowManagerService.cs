using SullyTech.Wpf.Controls.Window.Core.Interfaces;

namespace SullyTech.Wpf.Services.WindowManager.Interfaces;

public interface IWindowManagerService
{
    public Task<IWindow> GetWindowAsync(string windowId);

    public Task CloseWindowAsync(string windowId);
}