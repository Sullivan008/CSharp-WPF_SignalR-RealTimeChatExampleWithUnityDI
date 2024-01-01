using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;
using SullyTech.Wpf.Providers.Window.Interfaces;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Services.Window.Destroyer;

internal sealed class WindowDestroyerService : IWindowDestroyerService
{
    private readonly IWindowProvider _windowProvider;

    public WindowDestroyerService(IWindowProvider windowProvider)
    {
        _windowProvider = windowProvider;
    }

    public async Task DestroyWindowAsync(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId);

        Controls.Window.Core.UserControls.Window window = _windowProvider.GetWindow(windowId);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    await DestroyWindowAsync(standardWindow);
                    break;
                }
            case DialogWindow dialogWindow:
                {
                    await DestroyWindowAsync(dialogWindow);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(DestroyWindowAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task DestroyWindowAsync(Controls.Window.Core.UserControls.Window window)
    {
        Guard.Guard.ThrowIfNull(window);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    await DestroyWindowAsync(standardWindow);
                    break;
                }
            case DialogWindow dialogWindow:
                {
                    await DestroyWindowAsync(dialogWindow);
                    break;
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(DestroyWindowAsync)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task DestroyWindowAsync(StandardWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        await ((PresenterViewModel)((StandardWindowViewModel)window.DataContext).Presenter.DataContext).OnDestroyAsync();

        await ((StandardWindowViewModel)window.DataContext).OnDestroyAsync();
    }

    public async Task DestroyWindowAsync(DialogWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        await ((PresenterViewModel)((DialogWindowViewModel)window.DataContext).Presenter.DataContext).OnDestroyAsync();

        await ((DialogWindowViewModel)window.DataContext).OnDestroyAsync();
    }
}