using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Presenter.Views.MessageDialog.ViewModels.PresenterData.Initializer.Models;

public sealed class MessageDialogDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
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