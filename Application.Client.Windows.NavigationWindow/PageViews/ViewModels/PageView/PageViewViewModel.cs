using Application.Client.Common.ViewModels;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView.Interfaces;
using Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageViewData.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.NavigationWindow.PageViews.ViewModels.PageView;

public class PageViewViewModel<TPageViewDataViewModel> : ViewModelBase, IPageViewViewModel where TPageViewDataViewModel : IPageViewDataViewModel, new()
{
    public ICurrentNavigationWindowService CurrentNavigationWindowService { get; }

    protected PageViewViewModel(ICurrentNavigationWindowService currentNavigationWindowService)
    {
        CurrentNavigationWindowService = currentNavigationWindowService;
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