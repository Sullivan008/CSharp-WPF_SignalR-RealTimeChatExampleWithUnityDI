using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models;

public class ContentPresenterViewModelInitializerModel<TContentPresenterViewDataViewModelInitializerModel> 
    where TContentPresenterViewDataViewModelInitializerModel : IContentPresenterViewDataViewModelInitializerModel, new()
{
    private readonly TContentPresenterViewDataViewModelInitializerModel _viewDataInitializerModel = new();
    public TContentPresenterViewDataViewModelInitializerModel ViewDataInitializerModel
    {
        get
        {
            Guard.ThrowIfNull(_viewDataInitializerModel, nameof(ViewDataInitializerModel));

            return _viewDataInitializerModel!;
        }

        init => _viewDataInitializerModel = value;
    }
}