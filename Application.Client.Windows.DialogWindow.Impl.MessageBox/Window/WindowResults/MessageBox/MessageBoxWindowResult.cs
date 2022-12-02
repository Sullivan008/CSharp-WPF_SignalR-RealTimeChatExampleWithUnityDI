using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox.Enums;
using SullyTech.Guard;
using SullyTech.Wpf.Windows.Dialog.Result.Interfaces.DialogResult;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.WindowResults.MessageBox;

public class MessageBoxWindowResult : IDialogResult
{
    private readonly MessageBoxResult? _messageBoxResult;
    public MessageBoxResult MessageBoxResult
    {
        get
        {
            Guard.ThrowIfNull(_messageBoxResult, nameof(MessageBoxResult));

            return _messageBoxResult!.Value;
        }

        init => _messageBoxResult = value;
    }
}