using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models.Enums;
using SullyTech.Guard;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.Presenter.Models.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Initializer.Models;

public class MessageBoxViewModelInitializerModel : IPresenterViewModelInitializerModel
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

        init => _messageBoxButton = value;
    }
}