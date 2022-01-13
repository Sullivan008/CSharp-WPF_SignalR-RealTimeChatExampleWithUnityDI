using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Initializers.PageViewModelInitializer.Abstractions.Models;

public abstract class BasePageViewModelInitializerModel
{
    private readonly BasePageViewDataViewModelInitializerModel? _viewDataInitializerModel;
    public BasePageViewDataViewModelInitializerModel ViewDataInitializerModel
    {
        get
        {
            Guard.ThrowIfNull(_viewDataInitializerModel, nameof(ViewDataInitializerModel));

            return _viewDataInitializerModel!;
        }

        init => _viewDataInitializerModel = value;
    }
}