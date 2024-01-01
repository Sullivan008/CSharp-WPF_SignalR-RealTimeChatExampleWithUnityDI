using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Initializers.Models;
using SullyTech.Wpf.Controls.Window.Dialog.Core.UserControls;
using SullyTech.Wpf.Controls.Window.Standard.Core.UserControls;

namespace SullyTech.Wpf.Services.Navigation.Interfaces;

public interface INavigationService
{
    public Task NavigateToAsync<TPresenter, TPresenterViewModel>(string windowId, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel;

    public Task NavigateToAsync<TPresenter, TPresenterViewModel>(Controls.Window.Core.UserControls.Window window, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel;

    public Task NavigateToAsync<TPresenter, TPresenterViewModel>(StandardWindow window, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel;

    public Task NavigateToAsync<TPresenter, TPresenterViewModel>(DialogWindow window, PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TPresenter : Controls.Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel;
}