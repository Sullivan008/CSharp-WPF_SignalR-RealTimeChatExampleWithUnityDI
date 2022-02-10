using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent.ViewData;

namespace Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent;

public class MessageContentViewModel : ContentPresenterViewModel<MessageContentViewDataViewModel>
{
    public MessageContentViewModel(ICurrentDialogWindowService currentWindowService) : base(currentWindowService)
    { }
}