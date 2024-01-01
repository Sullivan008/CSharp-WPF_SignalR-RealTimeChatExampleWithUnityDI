using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;
using SullyTech.Wpf.Providers.Window.Interfaces;
using SullyTech.Wpf.Services.Window.Closer.Interfaces;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Services.Window.Closer;

internal sealed class WindowCloserService : IWindowCloserService
{
    private readonly IWindowProvider _windowProvider;

    private readonly IWindowDestroyerService _windowDestroyerService;

    public WindowCloserService(IWindowProvider windowProvider, IWindowDestroyerService windowDestroyerService)
    {
        _windowProvider = windowProvider;
        _windowDestroyerService = windowDestroyerService;
    }

    public async Task CloseAsync(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId);

        Controls.Window.Core.UserControls.Window window = _windowProvider.GetWindow(windowId);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    await CloseAsync(standardWindow);
                    break;
                }
            case DialogWindow dialogWindow:
                {
                    await CloseAsync(dialogWindow);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(CloseAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task CloseAsync(Controls.Window.Core.UserControls.Window window)
    {
        Guard.Guard.ThrowIfNull(window);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    await CloseAsync(standardWindow);
                    break;
                }
            case DialogWindow dialogWindow:
                {
                    await CloseAsync(dialogWindow);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(CloseAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task CloseAsync(StandardWindow window)
    {
        Guard.Guard.ThrowIfNull(window);

        await _windowDestroyerService.DestroyWindowAsync(window);

        window.Close();
    }

    public async Task CloseAsync(DialogWindow window)
    {
        Guard.Guard.ThrowIfNull(window);

        await _windowDestroyerService.DestroyWindowAsync(window);

        window.Close();
    }
}