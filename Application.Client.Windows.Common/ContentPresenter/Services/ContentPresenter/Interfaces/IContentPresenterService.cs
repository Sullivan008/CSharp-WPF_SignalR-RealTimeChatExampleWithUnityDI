using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models.Interfaces;
using Application.Client.Windows.Common.Services.CurrentWindowService.Interfaces;

namespace Application.Client.Windows.Common.ContentPresenter.Services.ContentPresenter.Interfaces;

public interface IContentPresenterService
{
    public IContentPresenterViewModel GetContentPresenterViewModel<TContentPresenterViewModel>(ICurrentWindowService currentApplicationWindowService)
        where TContentPresenterViewModel : IContentPresenterViewModel;

    public void InitializeContentPresenterViewModel(IContentPresenterViewModel contentPresenterViewModel,
        IContentPresenterViewDataViewModelInitializerModel contentPresenterViewModelInitializerModel);
}