using SignalRChatExampleClient.ViewModels;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Conditions.MainWindowViewModel
{
    public class MWVMCommandExecuteConditionsService : IMWVMCommandExecuteConditionsService
    {
        public bool CanLogin(string userName, bool isConnected) =>
            !string.IsNullOrEmpty(userName) &&
            userName.Length >= 2 &&
            isConnected;

        public bool CanLogout(bool isConnected, bool isLoggedIn) =>
            isConnected &&
            isLoggedIn;

        public bool CanSendMessage(string message, bool isConnected, ParticipantViewModel selectedParticipantViewModel) =>
            !string.IsNullOrEmpty(message) &&
            isConnected &&
            selectedParticipantViewModel != null &&
            selectedParticipantViewModel.IsLoggedIn;

        public bool CanSendBroadcastMessage(string message, bool isConnected) =>
            !string.IsNullOrEmpty(message) &&
            isConnected;
    }
}