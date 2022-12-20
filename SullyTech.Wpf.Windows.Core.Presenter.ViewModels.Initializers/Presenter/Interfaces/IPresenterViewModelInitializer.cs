using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Interfaces;

public interface IPresenterViewModelInitializer<in TIPresenterViewModel, in TIPresenterViewModelInitializerModel>
    where TIPresenterViewModel : IPresenterViewModel
    where TIPresenterViewModelInitializerModel : IPresenterViewModelInitializerModel
{
    public void Initialize(TIPresenterViewModel presenterViewModel, TIPresenterViewModelInitializerModel presenterViewModelInitializerModel);
}