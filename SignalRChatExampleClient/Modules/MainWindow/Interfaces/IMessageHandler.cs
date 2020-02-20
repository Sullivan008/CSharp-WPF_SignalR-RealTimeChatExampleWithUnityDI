using SignalRChatExampleClient.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Interfaces
{
    public interface IMessageHandler
    {
        ObservableCollection<ParticipantViewModel> Participants { get; set; }

        TaskFactory CtxTaskFactory { get; set; }

        void SendUnicastMessage(string senderConnectionId, string message, DateTime messagePostedDateTime, ParticipantViewModel selectedParticipantViewModel);

        void SendBroadcastMessage(string senderConnectionId, string message, DateTime messagePostedDateTime);

        void SendUnicastNotification(string senderConnectionId, string message, DateTime messagePostedDateTime);
    }
}
