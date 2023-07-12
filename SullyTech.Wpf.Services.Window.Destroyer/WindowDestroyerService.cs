using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Providers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Services.Window.Destroyer;

public sealed class WindowDestroyerService : IWindowDestroyerService
{
    private readonly IWindowProvider _windowProvider;

    public WindowDestroyerService(IWindowProvider windowProvider)
    {
        _windowProvider = windowProvider;
    }

    public async Task DestroyWindowAsync(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId, nameof(windowId));

        IWindow window = await _windowProvider.GetWindowAsync(windowId);

        switch (window)
        {
            case IStandardWindow standardWindow:
            {
                await DestroyWindowAsync(standardWindow);
                break;
            }
            case IDialogWindow dialogWindow:
            {
                await DestroyWindowAsync(dialogWindow);
                break;
            }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(DestroyWindowAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task DestroyWindowAsync(IWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    await DestroyWindowAsync(standardWindow);
                    break;
                }
            case IDialogWindow dialogWindow:
                {
                    await DestroyWindowAsync(dialogWindow);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(DestroyWindowAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task DestroyWindowAsync(IStandardWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        await ((IPresenterViewModel)((IStandardWindowViewModel)window.DataContext).Presenter.DataContext).Data.OnDestroyAsync();
        await ((IPresenterViewModel)((IStandardWindowViewModel)window.DataContext).Presenter.DataContext).OnDestroyAsync();

        await ((IStandardWindowViewModel)window.DataContext).Settings.OnDestroyAsync();
        await ((IStandardWindowViewModel)window.DataContext).OnDestroyAsync();
    }

    public async Task DestroyWindowAsync(IDialogWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        await ((IPresenterViewModel)((IDialogWindowViewModel)window.DataContext).Presenter.DataContext).Data.OnDestroyAsync();
        await ((IPresenterViewModel)((IDialogWindowViewModel)window.DataContext).Presenter.DataContext).OnDestroyAsync();

        await ((IDialogWindowViewModel)window.DataContext).Settings.OnDestroyAsync();
        await ((IDialogWindowViewModel)window.DataContext).OnDestroyAsync();
    }
}