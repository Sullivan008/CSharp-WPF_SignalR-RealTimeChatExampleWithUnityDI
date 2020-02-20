using SignalRChatExampleClient.ViewModels;
using System.Collections.ObjectModel;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.Common.Services
{
    public interface ICommonParticipantOperations
    {
        ObservableCollection<ParticipantViewModel> Participants { get; set; }

        ParticipantViewModel GetParticipantByConnectionId(string connectionId);

        ParticipantViewModel GetParticipantByUserName(string userName);

        void ClearChatMessages(ParticipantViewModel participantViewModel);

        void RemoveParticipantFromParticipants(ParticipantViewModel removeParticipantViewModel);
    }
}
