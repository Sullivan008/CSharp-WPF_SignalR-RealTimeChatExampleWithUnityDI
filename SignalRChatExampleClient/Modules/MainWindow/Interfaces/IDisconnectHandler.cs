using SignalRChatExampleClient.ViewModels;
using System.Collections.ObjectModel;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Interfaces
{
    public interface IDisconnectHandler
    {
        ObservableCollection<ParticipantViewModel> Participants { get; set; }

        ParticipantViewModel GetDisconnectedParticipant(string disconnectedConnectionId);

        void ClearDisconnectedParticipantChatMessages(ParticipantViewModel disconnectedParticipantViewModel);

        void RemoveDisconnectedParticipantFromParticipantList(ParticipantViewModel disconnectedParticipantViewModel);
    }
}
