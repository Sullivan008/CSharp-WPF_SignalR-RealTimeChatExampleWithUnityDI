using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;

namespace SullyTech.Wpf.Services.Window.Closer.Interfaces;

public interface IWindowCloserService
{
    public Task CloseAsync(string windowId);

    public Task CloseAsync(IWindow window);

    public Task CloseAsync(IStandardWindow window);

    public Task CloseAsync(IDialogWindow window);
}