using SullyTech.Wpf.Windows.Core.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Core.Services.Window.Interfaces;

public interface IWindowService
{
    public Task CloseWindowAsync(IWindow window);

    public Task SetWindowWidthAsync(IWindow window, double width);

    public Task SetWindowHeightAsync(IWindow window, double height);
}