using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.CurrentNavigationWindow.Options.Models.Interfaces;

public interface IContentPresenterNavigateOptions
{
    public bool HasInitializeData { get; }

    public Type ContentPresenterViewModelType { get; }

    public IContentPresenterViewModelInitializerModel? ContentPresenterViewModelInitializerModel { get; }
}