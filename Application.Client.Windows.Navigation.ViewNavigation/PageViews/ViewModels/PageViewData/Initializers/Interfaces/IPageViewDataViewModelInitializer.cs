using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Initializers.Models.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Interfaces;

namespace Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Initializers.Interfaces;

public interface IPageViewDataViewModelInitializer<in TPageViewDataViewModel, in TPageViewDataViewModelInitializerModel> 
    where TPageViewDataViewModel : IPageViewDataViewModel
    where TPageViewDataViewModelInitializerModel : IPageViewDataViewModelInitializerModel
{
    public void Initialize(TPageViewDataViewModel pageViewDataViewModel, TPageViewDataViewModelInitializerModel pageViewDataViewModelInitializerModel);
}