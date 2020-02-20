using SignalRChatExampleClient.Modules.Common.Services;
using SignalRChatExampleClient.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.Common.Handlers
{
    public class CommonParticipantOperations : ICommonParticipantOperations
    {
        public ObservableCollection<ParticipantViewModel> Participants { get; set; }

        public ParticipantViewModel GetParticipantByConnectionId(string connectionId) =>
            Participants.FirstOrDefault(x => x.ConnectionId == connectionId);

        public ParticipantViewModel GetParticipantByUserName(string userName) =>
            Participants.FirstOrDefault(x => x.Name == userName);

        public void ClearChatMessages(ParticipantViewModel participantViewModel)
        {
            Application.Current.Dispatcher?.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                    {
                        participantViewModel.Messages.Clear();
                    }
                ));
        }

        public void RemoveParticipantFromParticipants(ParticipantViewModel removeParticipantViewModel)
        {
            Application.Current.Dispatcher?.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                    {
                        Participants.Remove(Participants.Single(x => x.ConnectionId == removeParticipantViewModel.ConnectionId));
                    }
                ));
        }
    }
}
