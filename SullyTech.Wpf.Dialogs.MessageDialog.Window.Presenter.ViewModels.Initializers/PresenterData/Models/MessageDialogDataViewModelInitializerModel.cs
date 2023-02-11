using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Initializers.PresenterData.Models;

public sealed class MessageDialogDataViewModelInitializerModel : IMessageDialogDataViewModelInitializerModel
{
    private readonly string? _message;
    public string Message
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_message, nameof(Message));

            return _message!;
        }

        init => _message = value;
    }
}