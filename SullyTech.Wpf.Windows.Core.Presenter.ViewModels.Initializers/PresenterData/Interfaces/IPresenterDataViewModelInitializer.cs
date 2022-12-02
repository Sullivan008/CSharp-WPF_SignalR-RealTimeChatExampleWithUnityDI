using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

public interface IPresenterDataViewModelInitializer<in TPresenterDataViewModel, in TPresenterDataViewModelInitializerModel>
    where TPresenterDataViewModel : IPresenterDataViewModel
    where TPresenterDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public void Initialize(TPresenterDataViewModel presenterDataViewModel, TPresenterDataViewModelInitializerModel presenterDataViewModelInitializerModel);
}