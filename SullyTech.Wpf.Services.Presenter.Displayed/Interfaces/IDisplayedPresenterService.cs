using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;

namespace SullyTech.Wpf.Services.Presenter.Displayed.Interfaces;

public interface IDisplayedPresenterService
{
    public Task<IPresenter> GetDisplayedPresenter(string windowId);

    public Task<IPresenter> GetDisplayedPresenter(IWindow window);

    public Task<IPresenter> GetDisplayedPresenter(IStandardWindow window);

    public Task<IPresenter> GetDisplayedPresenter(IDialogWindow window);
}