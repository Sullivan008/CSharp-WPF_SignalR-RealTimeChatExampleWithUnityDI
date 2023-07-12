using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;

namespace SullyTech.Wpf.Services.Window.Title.Interfaces;

public interface IWindowTitleService
{
    public Task SetTitleAsync(string windowId, string title);

    public Task SetTitleAsync(IWindow window, string title);

    public Task SetTitleAsync(IStandardWindow window, string title);

    public Task SetTitleAsync(IDialogWindow window, string title);
}