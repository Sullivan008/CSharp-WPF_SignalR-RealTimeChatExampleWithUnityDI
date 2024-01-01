using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter.Initializers.Models;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window.Initializers.Models;

namespace SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.Interfaces;

public interface IStandardWindowService
{
    public Task ShowWindowAsync<TStandardWindow, TStandardWindowViewModel,
                                TPresenter, TPresenterViewModel>(StandardWindowViewModelInitializerModel? windowViewModelInitializerModel = null,
                                                                 PresenterViewModelInitializerModel? presenterViewModelInitializerModel = null)
        where TStandardWindow : Core.UserControls.StandardWindow
        where TStandardWindowViewModel : StandardWindowViewModel
        where TPresenter : Presenter.Core.UserControls.Presenter.Presenter
        where TPresenterViewModel : PresenterViewModel;
}