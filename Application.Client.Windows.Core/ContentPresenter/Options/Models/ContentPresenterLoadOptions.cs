using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.Options.Models;

public class ContentPresenterLoadOptions<TContentPresenterViewModel, TContentPresenterViewModelInitializerModel> : IContentPresenterLoadOptions 
    where TContentPresenterViewModel : IContentPresenterViewModel
    where TContentPresenterViewModelInitializerModel : IContentPresenterViewModelInitializerModel
{
    bool IContentPresenterLoadOptions.HasInitializeData => ContentPresenterViewModelInitializerModel != null;

    IContentPresenterViewModelInitializerModel? IContentPresenterLoadOptions.ContentPresenterViewModelInitializerModel => ContentPresenterViewModelInitializerModel;

    public Type ContentPresenterViewModelType => typeof(TContentPresenterViewModel);
    
    public TContentPresenterViewModelInitializerModel? ContentPresenterViewModelInitializerModel { get; init; }
}