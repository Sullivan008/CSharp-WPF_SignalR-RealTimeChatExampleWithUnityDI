using SullyTech.Guard;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData;

public class MessageBoxViewDataViewModel : PresenterDataViewModel
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
            _message = value;
            OnPropertyChanged();
        }
    }
}