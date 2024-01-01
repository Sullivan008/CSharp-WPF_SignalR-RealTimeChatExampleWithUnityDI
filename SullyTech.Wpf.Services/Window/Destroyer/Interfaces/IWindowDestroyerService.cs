using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;

namespace SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

public interface IWindowDestroyerService
{
    public Task DestroyWindowAsync(string windowId);

    public Task DestroyWindowAsync(Controls.Window.Core.UserControls.Window window);

    public Task DestroyWindowAsync(StandardWindow window);

    public Task DestroyWindowAsync(DialogWindow window);
}