using Application.Client.Windows.DialogWindow.Models.CustomDialogWindowResult;
using Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox.Enums;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.MessageBox.Window.WindowResults.MessageBox;

public class MessageBoxWindowResult : CustomDialogWindowResult
{
    private readonly MessageBoxResult? _messageBoxResult;
    public MessageBoxResult MessageBoxResult
    {
        get
        {
            Guard.ThrowIfNull(_messageBoxResult, nameof(MessageBoxResult));

            return _messageBoxResult!.Value;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(MessageBoxResult));

            _messageBoxResult = value;
        }
    }
}