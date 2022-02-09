using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Options.Models;

public class ContentPresenterNavigateOptions<TContentPresenterViewModel, TContentPresenterViewModelInitializerModel> : IContentPresenterNavigateOptions
    where TContentPresenterViewModel : IContentPresenterViewModel
    where TContentPresenterViewModelInitializerModel : IContentPresenterViewModelInitializerModel
{
    Type IContentPresenterNavigateOptions.ContentPresenterViewModelType => typeof(TContentPresenterViewModel);

    bool IContentPresenterNavigateOptions.HasInitializeData => ContentPresenterViewModelInitializerModel != null;

    IContentPresenterViewModelInitializerModel? IContentPresenterNavigateOptions.ContentPresenterViewModelInitializerModel => ContentPresenterViewModelInitializerModel;

    public TContentPresenterViewModelInitializerModel? ContentPresenterViewModelInitializerModel { get; init; }
}