using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent.Initializer.Models;
using Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent.ViewData;
using Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent.ViewData.Initializer.Models;

namespace Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent.Initializer;

public class MessageContentViewModelInitializer : IContentPresenterViewModelInitializer<MessageContentViewModel, MessageContentViewModelInitializerModel>
{
    private readonly IContentPresenterViewDataViewModelInitializer<MessageContentViewDataViewModel, MessageContentViewDataViewModelInitializerModel> _viewDataInitializer;

    public MessageContentViewModelInitializer(IContentPresenterViewDataViewModelInitializer<MessageContentViewDataViewModel, MessageContentViewDataViewModelInitializerModel> viewDataInitializer)
    {
        _viewDataInitializer = viewDataInitializer;
    }

    public void Initialize(MessageContentViewModel contentPresenterViewModel, MessageContentViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        _viewDataInitializer.Initialize(contentPresenterViewModel.ViewData, contentPresenterViewModelInitializerModel.ViewDataInitializerModel);
    }
}