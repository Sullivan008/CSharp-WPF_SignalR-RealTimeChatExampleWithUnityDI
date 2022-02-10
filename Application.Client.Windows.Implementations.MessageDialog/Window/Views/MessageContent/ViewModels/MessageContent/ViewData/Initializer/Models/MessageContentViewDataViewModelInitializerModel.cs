using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.MessageDialog.Window.Views.MessageContent.ViewModels.MessageContent.ViewData.Initializer.Models;

public class MessageContentViewDataViewModelInitializerModel : ContentPresenterViewDataViewModelInitializerModel
{
    private readonly string _message = string.Empty;
    public string Message
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_message, nameof(Message));

            return _message;
        }

        init
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Message));

            _message = value;
        }
    }
}