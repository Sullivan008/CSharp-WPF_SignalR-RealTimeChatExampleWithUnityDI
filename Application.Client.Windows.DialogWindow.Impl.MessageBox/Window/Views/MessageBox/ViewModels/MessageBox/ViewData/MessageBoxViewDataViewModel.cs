using App.Core.Guard.Implementation;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData;

public class MessageBoxViewDataViewModel : ContentPresenterViewDataViewModel
{
    private string _message = string.Empty;
    public string Message
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_message, nameof(Message));

            return _message;
        }

        set
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Message));
            _message = value;

            OnPropertyChanged();
        }
    }
}