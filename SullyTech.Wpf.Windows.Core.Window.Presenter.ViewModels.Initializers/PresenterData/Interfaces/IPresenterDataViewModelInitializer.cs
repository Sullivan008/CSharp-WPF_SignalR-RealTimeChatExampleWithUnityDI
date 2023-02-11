using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

public interface IPresenterDataViewModelInitializer<in TIPresenterDataViewModel, in TIPresenterDataViewModelInitializerModel>
    where TIPresenterDataViewModel : IPresenterDataViewModel
    where TIPresenterDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public void Initialize(TIPresenterDataViewModel presenterDataViewModel, TIPresenterDataViewModelInitializerModel presenterDataViewModelInitializerModel);
}