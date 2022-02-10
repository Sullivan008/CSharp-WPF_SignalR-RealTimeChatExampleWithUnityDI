using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter;
using Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;
using Application.Client.Windows.Implementations.MessageDialog.Window.View.Content.ViewModels.Content.ViewData;

namespace Application.Client.Windows.Implementations.MessageDialog.Window.View.Content.ViewModels.Content;

public class ContentViewModel : ContentPresenterViewModel<ContentViewDataViewModel>
{
    public ContentViewModel(ICurrentDialogWindowService currentWindowService) : base(currentWindowService)
    { }
}