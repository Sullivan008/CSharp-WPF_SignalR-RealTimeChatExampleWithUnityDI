using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;

public interface IContentPresenterLoadOptions
{
    internal bool HasInitializeData { get; }

    internal IContentPresenterViewModelInitializerModel? ContentPresenterViewModelInitializerModel { get; }

    public Type ContentPresenterViewModelType { get; }
}