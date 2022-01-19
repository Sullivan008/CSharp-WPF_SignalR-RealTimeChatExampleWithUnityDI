using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Initializers.Models.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Initializers.Models;

public class PageViewViewModelInitializerModel<TPageViewDataViewModelInitializerModel> where TPageViewDataViewModelInitializerModel : IPageViewDataViewModelInitializerModel, new()
{
    private readonly TPageViewDataViewModelInitializerModel _viewDataInitializerModel = new();
    public TPageViewDataViewModelInitializerModel ViewDataInitializerModel
    {
        get
        {
            Guard.ThrowIfNull(_viewDataInitializerModel, nameof(ViewDataInitializerModel));

            return _viewDataInitializerModel!;
        }

        init => _viewDataInitializerModel = value;
    }
}