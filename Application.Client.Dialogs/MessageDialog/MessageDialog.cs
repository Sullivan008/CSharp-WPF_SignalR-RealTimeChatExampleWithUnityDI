using System.Threading.Tasks;
using System.Windows;
using Application.Client.Dialogs.MessageDialog.Enums;
using Application.Client.Dialogs.MessageDialog.Exceptions;
using Application.Client.Dialogs.MessageDialog.Interfaces;
using Application.Client.Dialogs.MessageDialog.Models;

namespace Application.Client.Dialogs.MessageDialog
{
    public class MessageDialog : IMessageDialog
    {
        public async Task<MessageDialogResult> ShowDialogAsync(MessageDialogOptions options)
        {
            return await ShowAsync(options) switch
            {
                MessageBoxResult.OK => OnOkResult(),
                MessageBoxResult.Yes => OnYesResult(),
                MessageBoxResult.No => OnNoResult(),
                MessageBoxResult.Cancel => OnCancelResult(),
                MessageBoxResult.None => OnNoneResult(),
                _ => throw new MessageDialogUnknownResultTypeException("An unknown error occurred while reading the result of the dialog box!")
            };
        }

        private static Task<MessageBoxResult> ShowAsync(MessageDialogOptions options)
        {
            return options.Icon.HasValue
                ? Task.FromResult(MessageBox.Show(options.Content, options.Title, options.Button, options.Icon.Value))
                : Task.FromResult(MessageBox.Show(options.Content, options.Title, options.Button));
        }

        private static MessageDialogResult OnOkResult()
        {
            return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.Ok };
        }

        private static MessageDialogResult OnYesResult()
        {
            return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.Yes };
        }

        private static MessageDialogResult OnNoResult()
        {
            return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.No };
        }

        private static MessageDialogResult OnCancelResult()
        {
            return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.Cancel };
        }

        private static MessageDialogResult OnNoneResult()
        {
            return new MessageDialogResult { MessageDialogResultType = MessageDialogResultType.None };
        }
    }
}
