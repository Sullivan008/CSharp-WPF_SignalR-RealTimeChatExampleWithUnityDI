using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Providers.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Services.Presenter.Displayed.Interfaces;

namespace SullyTech.Wpf.Services.Presenter.Displayed;

public sealed class DisplayedPresenterService : IDisplayedPresenterService
{
    private readonly IWindowProvider _windowProvider;

    public DisplayedPresenterService(IWindowProvider windowProvider)
    {
        _windowProvider = windowProvider;
    }

    public async Task<IPresenter> GetDisplayedPresenter(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId, nameof(windowId));

        IWindow window = await _windowProvider.GetWindowAsync(windowId);

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    return await GetDisplayedPresenter(standardWindow);
                }
            case IDialogWindow dialogWindow:
                {
                    return await GetDisplayedPresenter(dialogWindow);
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(GetDisplayedPresenter)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task<IPresenter> GetDisplayedPresenter(IWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        switch (window)
        {
            case IStandardWindow standardWindow:
                {
                    return await GetDisplayedPresenter(standardWindow);
                }
            case IDialogWindow dialogWindow:
                {
                    return await GetDisplayedPresenter(dialogWindow);
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(GetDisplayedPresenter)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public async Task<IPresenter> GetDisplayedPresenter(IStandardWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        IPresenter result = ((IStandardWindowViewModel)window.DataContext).Presenter;

        return await Task.FromResult(result);
    }

    public async Task<IPresenter> GetDisplayedPresenter(IDialogWindow window)
    {
        Guard.Guard.ThrowIfNull(window, nameof(window));

        IPresenter result = ((IDialogWindowViewModel)window.DataContext).Presenter;

        return await Task.FromResult(result);
    }
}