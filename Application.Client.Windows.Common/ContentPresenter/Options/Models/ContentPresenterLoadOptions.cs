using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.Options.Models;

public class ContentPresenterLoadOptions<TContentPresenterViewModel, TContentPresenterViewModelInitializerModel> : IContentPresenterLoadOptions
{
    public Type ContentPresenterViewModelType => typeof(TContentPresenterViewModel);

    public Type ContentPresenterViewModelInitializerModelType => typeof(TContentPresenterViewModelInitializerModel);

    public bool HasInitializeData => ContentPresenterViewModelInitializerModel != null;

    public IContentPresenterViewModelInitializerModel? ContentPresenterViewModelInitializerModel { get; init; }
}