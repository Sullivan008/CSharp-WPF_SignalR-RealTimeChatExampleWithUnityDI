using Application.Client.Common.ViewModels;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;

public class ContentPresenterViewModel<TContentPresenterViewDataViewModel> : ViewModelBase, IContentPresenterViewModel 
    where TContentPresenterViewDataViewModel : IContentPresenterViewDataViewModel, new()
{
    public ICurrentWindowService CurrentWindowService { get; }

    protected ContentPresenterViewModel(ICurrentWindowService currentWindowService)
    {
        CurrentWindowService = currentWindowService;
    }

    private TContentPresenterViewDataViewModel _viewData = new();
    public TContentPresenterViewDataViewModel ViewData
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