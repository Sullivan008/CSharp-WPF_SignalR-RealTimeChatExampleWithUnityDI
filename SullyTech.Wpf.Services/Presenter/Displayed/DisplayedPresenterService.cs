using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Dialog.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;
using SullyTech.Wpf.Providers.Window.Interfaces;
using SullyTech.Wpf.Services.Presenter.Displayed.Interfaces;

namespace SullyTech.Wpf.Services.Presenter.Displayed;

internal sealed class DisplayedPresenterService : IDisplayedPresenterService
{
    private readonly IWindowProvider _windowProvider;

    public DisplayedPresenterService(IWindowProvider windowProvider)
    {
        _windowProvider = windowProvider;
    }

    public Controls.Presenter.Core.UserControls.Presenter.Presenter GetDisplayedPresenter(string windowId)
    {
        Guard.Guard.ThrowIfNullOrWhitespace(windowId);

        Controls.Window.Core.UserControls.Window window = _windowProvider.GetWindow(windowId);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    return GetDisplayedPresenter(standardWindow);
                }
            case DialogWindow dialogWindow:
                {
                    return GetDisplayedPresenter(dialogWindow);
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(GetDisplayedPresenter)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public Controls.Presenter.Core.UserControls.Presenter.Presenter GetDisplayedPresenter(Controls.Window.Core.UserControls.Window window)
    {
        Guard.Guard.ThrowIfNull(window);

        switch (window)
        {
            case StandardWindow standardWindow:
                {
                    return GetDisplayedPresenter(standardWindow);
                }
            case DialogWindow dialogWindow:
                {
                    return GetDisplayedPresenter(dialogWindow);
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(GetDisplayedPresenter)} - Operation for following Window Type [Type: {window.GetType().FullName}]");
        }
    }

    public Controls.Presenter.Core.UserControls.Presenter.Presenter GetDisplayedPresenter(StandardWindow window)
    {
        Guard.Guard.ThrowIfNull(window);

        return ((StandardWindowViewModel)window.DataContext).Presenter;
    }

    public Controls.Presenter.Core.UserControls.Presenter.Presenter GetDisplayedPresenter(DialogWindow window)
    {
        Guard.Guard.ThrowIfNull(window);

        return ((DialogWindowViewModel)window.DataContext).Presenter;
    }
}