using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.PresenterData;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Initializer.Models.PresenterData;

public sealed class MessageDialogPresenterDataViewModelInitializerModel : PresenterDataViewModelInitializerModel, IMessageDialogPresenterDataViewModelInitializerModel
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