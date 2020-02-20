using SignalRChatExampleClient.ViewModels;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Conditions.MainWindowViewModel
{
    public interface IMWVMCommandExecuteConditionsService
    {
        bool CanLogin(string userName, bool isConnected);

        bool CanLogout(bool isConnected, bool isLoggedIn);

        bool CanSendMessage(string message, bool isConnected, ParticipantViewModel selectedParticipantViewModel);

        bool CanSendBroadcastMessage(string message, bool isConnected);
    }
}
