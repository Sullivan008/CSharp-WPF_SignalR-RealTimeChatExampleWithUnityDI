using Application.Client.Common.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageViewData.Interfaces;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.PageViews.ViewModels.PageView;

public class PageViewViewModel<TPageViewDataViewModel> : ViewModelBase, IPageViewViewModel where TPageViewDataViewModel : IPageViewDataViewModel, new()
{
    public IViewNavigationService ViewNavigationService { get; }

    protected PageViewViewModel(IViewNavigationService viewNavigationService)
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