using System.Windows;
using SullyTech.Wpf.Providers.Window.Interfaces;

namespace SullyTech.Wpf.Providers.Window;

internal sealed class WindowProvider : IWindowProvider
{
    public Controls.Window.Core.UserControls.Window GetWindow(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId);

        return Application.Current.Windows.OfType<Controls.Window.Core.UserControls.Window>()
                                          .First(x => x.Id == windowId);
    }
}