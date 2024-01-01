using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;
using SullyTech.Wpf.Providers.Window.Interfaces;
using SullyTech.Wpf.Services.Window.Title.Interfaces;

namespace SullyTech.Wpf.Services.Window.Title;

internal sealed class WindowTitleService : IWindowTitleService
{
    private readonly IWindowProvider _windowProvider;

    public WindowTitleService(IWindowProvider windowProvider)
    {
        _windowProvider = windowProvider;
    }

    public void SetTitle(string windowId, string title)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId);
        Guard.Guard.ThrowIfNullOrWhitespace(title);

        Controls.Window.Core.UserControls.Window window = _windowProvider.GetWindow(windowId);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    SetTitle(standardWindow, title);
                    break;
                }
            case DialogWindow dialogWindow:
                {
                    SetTitle(dialogWindow, title);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(SetTitle)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public void SetTitle(Controls.Window.Core.UserControls.Window window, string title)
    {
        Guard.Guard.ThrowIfNull(window);
        Guard.Guard.ThrowIfNullOrWhitespace(title);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    SetTitle(standardWindow, title);
                    break;
                }
            case DialogWindow dialogWindow:
                {
                    SetTitle(dialogWindow, title);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(SetTitle)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public void SetTitle(StandardWindow window, string title)
    {
        Guard.Guard.ThrowIfNull(window);
        Guard.Guard.ThrowIfNullOrWhitespace(title);

        ((StandardWindowViewModel)window.DataContext).Title = title;
    }

    public void SetTitle(DialogWindow window, string title)
    {
        Guard.Guard.ThrowIfNull(window);
        Guard.Guard.ThrowIfNullOrWhitespace(title);

        ((DialogWindowViewModel)window.DataContext).Title = title;
    }
}