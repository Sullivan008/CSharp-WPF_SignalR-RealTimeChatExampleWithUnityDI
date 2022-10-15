using App.Core.Guard.Implementation;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models.Enums;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer.Models;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models;

public class MessageBoxViewModelInitializerModel : ContentPresenterViewModelInitializerModel<MessageBoxViewDataViewModelInitializerModel>
{
    public MessageBoxIcon? MessageBoxIcon { get; init; }

    private readonly MessageBoxButton? _messageBoxButton;
    public MessageBoxButton MessageBoxButton
    {
        get
        {
            Guard.ThrowIfNull(_messageBoxButton, nameof(MessageBoxButton));

            return _messageBoxButton!.Value;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(MessageBoxButton));

            _messageBoxButton = value;
        }
    }
}