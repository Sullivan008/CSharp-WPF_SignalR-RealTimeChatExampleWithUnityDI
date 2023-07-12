using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;

public interface IPresenterDataViewModelInitializer<in TIPresenterDataViewModel, in TIPresenterDataViewModelInitializerModel>
    where TIPresenterDataViewModel : IPresenterDataViewModel
    where TIPresenterDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    public void Initialize(TIPresenterDataViewModel presenterDataViewModel, TIPresenterDataViewModelInitializerModel presenterDataViewModelInitializerModel);
}