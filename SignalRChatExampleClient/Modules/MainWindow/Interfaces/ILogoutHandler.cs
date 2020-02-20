using SignalRChatExampleClient.ViewModels;
using System.Collections.ObjectModel;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Interfaces
{
    public interface ILogoutHandler
    {
        ObservableCollection<ParticipantViewModel> Participants { get; set; }

        ParticipantViewModel GetLoggedOutParticipant(string loggedOutUserName);

        void ClearLoggedOutParticipantChatMessages(ParticipantViewModel loggedOutParticipantViewModel);

        void RemoveLoggedOutParticipantFromParticipantList(ParticipantViewModel loggedOutParticipantViewModel);
    }
}
