using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Providers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;
using SullyTech.Wpf.Services.Window.Closer.Interfaces;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Services.Window.Closer;

public sealed class WindowCloserService : IWindowCloserService
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
        Guard.Guard.ThrowIfNullOrWhitespace(windowId, nameof(windowId));

        IWindow window = await _windowProvider.GetWindowAsync(windowId);

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    await CloseAsync(standardWindow);
                    break;
                }
            case IDialogWindow dialogWindow:
                {
                    await CloseAsync(dialogWindow);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(CloseAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task CloseAsync(IWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    await CloseAsync(standardWindow);
                    break;
                }
            case IDialogWindow dialogWindow:
                {
                    await CloseAsync(dialogWindow);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(CloseAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task CloseAsync(IStandardWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        await _windowDestroyerService.DestroyWindowAsync(window);

        window.Close();
    }

    public async Task CloseAsync(IDialogWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        await _windowDestroyerService.DestroyWindowAsync(window);

        window.Close();
    }
}