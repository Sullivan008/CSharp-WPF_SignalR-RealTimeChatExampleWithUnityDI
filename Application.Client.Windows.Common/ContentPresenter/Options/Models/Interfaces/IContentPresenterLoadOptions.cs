using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;

public interface IContentPresenterLoadOptions
{
    public bool HasInitializeData { get; }

    public Type ContentPresenterViewModelType { get; }
    
    public Type ContentPresenterViewModelInitializerModelType { get; }

    public IContentPresenterViewModelInitializerModel? ContentPresenterViewModelInitializerModel { get; }
}