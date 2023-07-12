using System.Windows;
using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Services.WindowDestroyer.Interfaces;
using SullyTech.Wpf.Services.WindowManager.Interfaces;

namespace SullyTech.Wpf.Services.WindowManager;

public sealed class WindowManagerService : IWindowManagerService
{
    private readonly IWindowDestroyerService _windowDestroyerService;

    public WindowManagerService(IWindowDestroyerService windowDestroyerService)
    {
        _windowDestroyerService = windowDestroyerService;
    }

    public async Task<IWindow> GetWindowAsync(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId, nameof(windowId));

        IWindow result = Application.Current.Windows.OfType<IWindow>()
                                                    .Single(x => x.Id == windowId);

        return await Task.FromResult(result);
    }

    public async Task CloseWindowAsync(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId, nameof(windowId));

        IWindow window = await GetWindowAsync(windowId);

        await _windowDestroyerService.DestroyWindowAsync(window);
        
        window.Close();
    }
}