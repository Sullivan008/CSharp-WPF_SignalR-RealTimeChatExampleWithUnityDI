using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Providers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Services.Window.Title.Interfaces;

namespace SullyTech.Wpf.Services.Window.Title;

public sealed class WindowTitleService : IWindowTitleService
{
    private readonly IWindowProvider _windowProvider;

    public WindowTitleService(IWindowProvider windowProvider)
    {
        _windowProvider = windowProvider;
    }

    public async Task SetTitleAsync(string windowId, string title)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId, nameof(windowId));
        Guard.Guard.ThrowIfNullOrWhitespace(title, nameof(title));

        IWindow window = await _windowProvider.GetWindowAsync(windowId);

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    await SetTitleAsync(standardWindow, title);
                    break;
                }
            case IDialogWindow dialogWindow:
                {
                    await SetTitleAsync(dialogWindow, title);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(SetTitleAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task SetTitleAsync(IWindow window, string title)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));
        Guard.Guard.ThrowIfNullOrWhitespace(title, nameof(title));

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    await SetTitleAsync(standardWindow, title);
                    break;
                }
            case IDialogWindow dialogWindow:
                {
                    await SetTitleAsync(dialogWindow, title);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(SetTitleAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task SetTitleAsync(IStandardWindow window, string title)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));
        Guard.Guard.ThrowIfNullOrWhitespace(title, nameof(title));

        ((IStandardWindowViewModel)window.DataContext).Settings.Title = title;

        await Task.CompletedTask;
    }

    public async Task SetTitleAsync(IDialogWindow window, string title)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));
        Guard.Guard.ThrowIfNullOrWhitespace(title, nameof(title));

        ((IDialogWindowViewModel)window.DataContext).Settings.Title = title;

        await Task.CompletedTask;
    }
}