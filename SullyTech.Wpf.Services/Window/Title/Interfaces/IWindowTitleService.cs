using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;

namespace SullyTech.Wpf.Services.Window.Title.Interfaces;

public interface IWindowTitleService
{
    public void SetTitle(string windowId, string title);

    public void SetTitle(Controls.Window.Core.UserControls.Window window, string title);

    public void SetTitle(StandardWindow window, string title);

    public void SetTitle(DialogWindow window, string title);
}