using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer.Models;

public class MessageBoxViewDataViewModelInitializerModel : ContentPresenterViewDataViewModelInitializerModel
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