namespace SignalRChatExampleClient.Modules.Dialog.Interfaces
{
    public interface INotificationDialogWindowService
    {
        void ShowErrorMessageBox(string content);

        void ShowWarningMessageBox(string content);
    }
}
