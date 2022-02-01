using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models.Interfaces;

namespace Application.Client.Windows.ContentPresenter.Services.ContentPresenter.Interfaces;

public interface IContentPresenterService
{
    public IContentPresenterViewModel GetContentPresenterViewModel<TContentPresenterViewModel>(ICurrentApplicationWindowService currentApplicationWindowService)
        where TContentPresenterViewModel : IContentPresenterViewModel;

    public void InitializeContentPresenterViewModel(IContentPresenterViewModel contentPresenterViewModel,
        IContentPresenterViewDataViewModelInitializerModel contentPresenterViewModelInitializerModel);
}