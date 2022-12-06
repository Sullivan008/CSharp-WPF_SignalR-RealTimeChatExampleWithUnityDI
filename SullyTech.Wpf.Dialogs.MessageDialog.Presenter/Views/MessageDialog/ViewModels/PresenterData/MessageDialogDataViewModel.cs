using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.PresenterData;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.PresenterData;

public sealed class MessageDialogDataViewModel : PresenterDataViewModel
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