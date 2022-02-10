using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.MessageDialog.Window.View.Content.ViewModels.Content.Initializer.Models;
using Application.Client.Windows.Implementations.MessageDialog.Window.View.Content.ViewModels.Content.ViewData;
using Application.Client.Windows.Implementations.MessageDialog.Window.View.Content.ViewModels.Content.ViewData.Initializer.Models;

namespace Application.Client.Windows.Implementations.MessageDialog.Window.View.Content.ViewModels.Content.Initializer;

public class ContentViewModelInitializer : IContentPresenterViewModelInitializer<ContentViewModel, ContentViewModelInitializerModel>
{
    private readonly IContentPresenterViewDataViewModelInitializer<ContentViewDataViewModel, ContentViewDataViewModelInitializerModel> _viewDataInitializer;

    public ContentViewModelInitializer(IContentPresenterViewDataViewModelInitializer<ContentViewDataViewModel, ContentViewDataViewModelInitializerModel> viewDataInitializer)
    {
        _viewDataInitializer = viewDataInitializer;
    }

    public void Initialize(ContentViewModel contentPresenterViewModel, ContentViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        _viewDataInitializer.Initialize(contentPresenterViewModel.ViewData, contentPresenterViewModelInitializerModel.ViewDataInitializerModel);
    }
}