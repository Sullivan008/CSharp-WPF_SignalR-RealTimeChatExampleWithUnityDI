using Application.Client.Common.ViewModels;
using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter;

public class ContentPresenterViewModel<TContentPresenterViewDataViewModel> : ViewModelBase, IContentPresenterViewModel 
    where TContentPresenterViewDataViewModel : IContentPresenterViewDataViewModel, new()
{
    public ICurrentApplicationWindowService CurrentWindowService { get; }

    protected ContentPresenterViewModel(ICurrentApplicationWindowService currentWindowService)
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