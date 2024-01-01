using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;

namespace SullyTech.Wpf.Services.Presenter.Displayed.Interfaces;

public interface IDisplayedPresenterService
{
    public Controls.Presenter.Core.UserControls.Presenter.Presenter GetDisplayedPresenter(string windowId);

    public Controls.Presenter.Core.UserControls.Presenter.Presenter GetDisplayedPresenter(Controls.Window.Core.UserControls.Window window);

    public Controls.Presenter.Core.UserControls.Presenter.Presenter GetDisplayedPresenter(StandardWindow window);

    public Controls.Presenter.Core.UserControls.Presenter.Presenter GetDisplayedPresenter(DialogWindow window);
}