using SignalRChatExampleClient.Modules.Dialog.Interfaces;
using System.Windows;

namespace SignalRChatExampleClient.Modules.Dialog.Services
{
    public class NotificationDialogWindowService : INotificationDialogWindowService
    {
        public void ShowErrorMessageBox(string content) =>
            MessageBox.Show(content, nameof(MessageBoxImage.Error), MessageBoxButton.OK, MessageBoxImage.Error);

        public void ShowWarningMessageBox(string content) =>
            MessageBox.Show(content, nameof(MessageBoxImage.Warning), MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}
