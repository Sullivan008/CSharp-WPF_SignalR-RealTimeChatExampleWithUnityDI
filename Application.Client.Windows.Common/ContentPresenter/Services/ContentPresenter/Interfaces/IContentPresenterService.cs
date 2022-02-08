using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;

public interface IContentPresenterService
{
    public IContentPresenterViewModel GetContentPresenterViewModel(Type contentPresenterViewModelType, ICurrentWindowService currentWindowService);

    public void InitializeContentPresenterViewModel(IContentPresenterViewModel contentPresenterViewModel, IContentPresenterViewModelInitializerModel contentPresenterViewModelInitializerModel);
}