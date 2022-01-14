using Application.Client.Common.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewDataViewModel.Abstractions;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.PageViewModel.Abstractions;

public abstract class PageViewModelBase<TPageViewDataViewModel> : ViewModelBase where TPageViewDataViewModel : PageViewDataViewModelBase, new()
{
    protected readonly IViewNavigationService ViewNavigationService;

    protected PageViewModelBase(IViewNavigationService viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }

    private TPageViewDataViewModel _viewData = new();
    public TPageViewDataViewModel ViewData
    {
        get => _viewData;
        set
        {
            Guard.ThrowIfNull(value, nameof(ViewData));
            _viewData = value;

            OnPropertyChanged();
        }
    }
}