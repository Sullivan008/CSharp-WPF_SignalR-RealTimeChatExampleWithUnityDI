using System.ComponentModel;
using System.Runtime.CompilerServices;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;

public class ContentPresenterViewModel<TContentPresenterViewDataViewModel> : INotifyPropertyChanged, IContentPresenterViewModel 
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

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (name != null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}