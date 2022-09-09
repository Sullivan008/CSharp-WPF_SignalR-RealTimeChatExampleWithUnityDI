using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models;

public class ContentPresenterViewModelInitializerModel<TContentPresenterViewDataViewModelInitializerModel> : IContentPresenterViewModelInitializerModel
    where TContentPresenterViewDataViewModelInitializerModel : IContentPresenterViewDataViewModelInitializerModel, new()
{
    public TContentPresenterViewDataViewModelInitializerModel ViewDataInitializerModel { get; init; } = new();
}