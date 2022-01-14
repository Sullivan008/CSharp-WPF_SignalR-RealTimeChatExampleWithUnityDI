using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModelInitializers.PageViewModelInitializer.InitializerModels.Abstractions;

public abstract class PageViewModelInitializerModelBase<TPageViewDataViewModelInitializerModel> where TPageViewDataViewModelInitializerModel : PageViewDataViewModelInitializerModelBase, new()
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