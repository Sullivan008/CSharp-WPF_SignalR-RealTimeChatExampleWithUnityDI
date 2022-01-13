using Application.Client.Common.ViewModels;
using Application.Client.Windows.Navigation.ViewNavigation.Services.ViewNavigation.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;

public abstract class PageViewModelBase : ViewModelBase
{
    protected readonly IViewNavigationService ViewNavigationService;

    protected PageViewModelBase(IViewNavigationService viewNavigationService)
    {
        ViewNavigationService = viewNavigationService;
    }

    private BasePageViewDataViewModel? _viewData;
    public BasePageViewDataViewModel ViewData
    {
        get => _viewData!;
        set
        {
            Guard.ThrowIfNull(value, nameof(ViewData));
            _viewData = value;

            OnPropertyChanged();
        }
    }
}