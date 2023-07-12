using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;

namespace SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

public interface IWindowDestroyerService
{
    public Task DestroyWindowAsync(string windowId);

    public Task DestroyWindowAsync(IWindow window);

    public Task DestroyWindowAsync(IStandardWindow window);

    public Task DestroyWindowAsync(IDialogWindow window);
}