using Application.Client.Common.ViewModels;
using Application.Client.Windows.NavigationWindow.PageViews.Services.PageViewNavigation.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageViewData.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView;

public class PageViewViewModel<TPageViewDataViewModel> : ViewModelBase, IPageViewViewModel where TPageViewDataViewModel : IPageViewDataViewModel, new()
{
    public IPageViewNavigationService ViewNavigationService { get; }

    protected PageViewViewModel(IPageViewNavigationService viewNavigationService)
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