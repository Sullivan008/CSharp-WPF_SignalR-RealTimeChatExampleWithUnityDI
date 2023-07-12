using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.PresenterData;

public sealed class MessageDialogPresenterDataViewModel : PresenterDataViewModel, IMessageDialogPresenterDataViewModel
{
    private string? _message;
    public string Message
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_message, nameof(Message));

            return _message!;
        }

        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }
}