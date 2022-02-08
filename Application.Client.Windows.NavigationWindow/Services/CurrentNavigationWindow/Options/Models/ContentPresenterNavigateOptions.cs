using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Options.Models;

public class ContentPresenterNavigateOptions<TContentPresenterViewModel, TContentPresenterViewModelInitializerModel> : IContentPresenterNavigateOptions
    where TContentPresenterViewModel : IContentPresenterViewModel
    where TContentPresenterViewModelInitializerModel : IContentPresenterViewModelInitializerModel
{
    public Type ContentPresenterViewModelType => typeof(TContentPresenterViewModel);

    public bool HasInitializeData => ContentPresenterViewModelInitializerModel != null;

    public TContentPresenterViewModelInitializerModel? ContentPresenterViewModelInitializerModel { get; init; }

    IContentPresenterViewModelInitializerModel? IContentPresenterNavigateOptions.ContentPresenterViewModelInitializerModel => ContentPresenterViewModelInitializerModel;
}