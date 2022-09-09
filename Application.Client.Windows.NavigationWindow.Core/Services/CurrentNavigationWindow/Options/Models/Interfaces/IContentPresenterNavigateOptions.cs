using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Core.Services.CurrentNavigationWindow.Options.Models.Interfaces;

public interface IContentPresenterNavigateOptions
{
    internal bool HasInitializeData { get; }

    internal Type ContentPresenterViewModelType { get; }

    internal IContentPresenterViewModelInitializerModel? ContentPresenterViewModelInitializerModel { get; }
}