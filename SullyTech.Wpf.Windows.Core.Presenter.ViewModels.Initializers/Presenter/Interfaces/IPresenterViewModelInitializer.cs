using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;

public interface IPresenterViewModelInitializer<in TPresenterViewModel, in TPresenterViewModelInitializerModel>
    where TPresenterViewModel : IPresenterViewModel
    where TPresenterViewModelInitializerModel : IPresenterViewModelInitializerModel
{
    public void Initialize(TPresenterViewModel presenterViewModel, TPresenterViewModelInitializerModel presenterViewModelInitializerModel);
}