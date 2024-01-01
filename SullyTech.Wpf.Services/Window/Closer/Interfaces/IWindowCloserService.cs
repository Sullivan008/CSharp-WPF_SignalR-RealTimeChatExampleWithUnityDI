using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;

namespace SullyTech.Wpf.Services.Window.Closer.Interfaces;

public interface IWindowCloserService
{
    public Task CloseAsync(string windowId);

    public Task CloseAsync(Controls.Window.Core.UserControls.Window window);

    public Task CloseAsync(StandardWindow window);

    public Task CloseAsync(DialogWindow window);
}