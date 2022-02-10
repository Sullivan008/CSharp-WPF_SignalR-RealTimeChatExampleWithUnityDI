using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Interfaces;
using Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent.ViewData.Initializer.Models;

namespace Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent.ViewData.Initializer;

public class MessageContentViewDataViewModelInitializer : IContentPresenterViewDataViewModelInitializer<MessageContentViewDataViewModel, MessageContentViewDataViewModelInitializerModel>
{
    public void Initialize(MessageContentViewDataViewModel messageContentViewDataViewModel, MessageContentViewDataViewModelInitializerModel messageContentViewDataViewModelInitializerModel)
    {
        messageContentViewDataViewModel.Message = messageContentViewDataViewModelInitializerModel.Message;
    }
}