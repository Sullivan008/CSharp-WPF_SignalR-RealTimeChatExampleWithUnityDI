using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenter.Initializers.Models;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models.Enums;
using Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData.Initializer.Models;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models;

public class MessageBoxViewModelInitializerModel : ContentPresenterViewModelInitializerModel<MessageBoxViewDataViewModelInitializerModel>
{
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