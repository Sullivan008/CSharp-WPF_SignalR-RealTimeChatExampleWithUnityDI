using SignalRChatExampleClient.ViewModels;
using System.Collections.ObjectModel;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Interfaces
{
    public interface IReconnectHandler
    {
        ObservableCollection<ParticipantViewModel> Participants { get; set; }

        ParticipantViewModel GetReconnectionParticipant(string reconnectionConnectionId);
    }
}
