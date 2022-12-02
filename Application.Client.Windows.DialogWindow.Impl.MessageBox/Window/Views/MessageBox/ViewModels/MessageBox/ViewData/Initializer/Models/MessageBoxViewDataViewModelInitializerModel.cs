using SullyTech.Guard;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer.Models;

public class MessageBoxViewDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
{
    private readonly string _message = string.Empty;
    public string Message
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_message, nameof(Message));

            return _message;
        }

        init => _message = value;
    }
}