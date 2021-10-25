using Application.Client.Dialogs.MessageDialog.Enums;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.MessageDialog.Models
{
    public class MessageDialogResult
    {
        private readonly MessageDialogResultType? _messageDialogResultType;
        public MessageDialogResultType MessageDialogResultType
        {
            get
            {
                Guard.ThrowIfNull(_messageDialogResultType, nameof(MessageDialogResultType));

                return _messageDialogResultType!.Value;
            }

            init => _messageDialogResultType = value;
        }
    }
}
