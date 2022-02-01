using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;

namespace Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;

public interface IContentPresenterViewDataViewModelInitializer<in TContentPresenterViewDataViewModel, in TContentPresenterViewDataViewModelInitializerModel> 
    where TContentPresenterViewDataViewModel : IContentPresenterViewDataViewModel
    where TContentPresenterViewDataViewModelInitializerModel : IContentPresenterViewDataViewModelInitializerModel
{
    public void Initialize(TContentPresenterViewDataViewModel contentPresenterViewDataViewModel, 
                           TContentPresenterViewDataViewModelInitializerModel contentPresenterViewDataViewModelInitializerModel);
}