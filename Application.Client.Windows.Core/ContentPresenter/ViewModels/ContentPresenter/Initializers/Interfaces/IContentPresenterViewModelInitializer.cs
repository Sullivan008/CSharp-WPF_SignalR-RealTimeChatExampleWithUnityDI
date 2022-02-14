using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;

public interface IContentPresenterViewModelInitializer<in TContentPresenterViewModel, in TContentPresenterViewModelInitializerModel> 
    where TContentPresenterViewModel : IContentPresenterViewModel
    where TContentPresenterViewModelInitializerModel : IContentPresenterViewModelInitializerModel
{
    public void Initialize(TContentPresenterViewModel contentPresenterViewModel, TContentPresenterViewModelInitializerModel contentPresenterViewModelInitializerModel);
}