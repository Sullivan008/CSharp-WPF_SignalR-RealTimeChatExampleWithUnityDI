using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models;

public class ContentPresenterViewModelInitializerModel<TContentPresenterViewDataViewModelInitializerModel> 
    where TContentPresenterViewDataViewModelInitializerModel : IContentPresenterViewDataViewModelInitializerModel, new()
{
    public TContentPresenterViewDataViewModelInitializerModel ViewDataInitializerModel { get; init; } = new();
}