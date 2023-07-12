using System.Windows;
using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Providers.Window.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Providers.Window;

public sealed class WindowProvider : IWindowProvider
{
    public async Task<IWindow> GetWindowAsync(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId, nameof(windowId));

        IWindow result = Application.Current.Windows.OfType<IWindow>()
                                                    .Single(x => x.Id == windowId);

        return await Task.FromResult(result);
    }
}