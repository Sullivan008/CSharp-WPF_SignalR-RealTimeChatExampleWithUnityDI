using SignalRChatExampleClient.Modules.Common.Services;
using SignalRChatExampleClient.Modules.MainWindow.Interfaces;
using SignalRChatExampleClient.ViewModels;
using System;
using System.Collections.ObjectModel;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Handlers
{
    public class DisconnectHandler : IDisconnectHandler
    {
        private readonly ICommonParticipantOperations _commonParticipantOperations;

        private ObservableCollection<ParticipantViewModel> _participants;
        public ObservableCollection<ParticipantViewModel> Participants
        {
            get => _participants;
            set
            {
                _participants = value;
                _commonParticipantOperations.Participants = value;
            }
        }

        public DisconnectHandler(ICommonParticipantOperations commonParticipantOperations)
        {
            _commonParticipantOperations = commonParticipantOperations ??
                                           throw new ArgumentNullException(nameof(commonParticipantOperations));
        }

        public ParticipantViewModel GetDisconnectedParticipant(string disconnectionConnectionId) =>
            _commonParticipantOperations.GetParticipantByConnectionId(disconnectionConnectionId);

        public void ClearDisconnectedParticipantChatMessages(ParticipantViewModel disconnectedParticipantViewModel)
        {
            _commonParticipantOperations.ClearChatMessages(disconnectedParticipantViewModel);
        }

        public void RemoveDisconnectedParticipantFromParticipantList(ParticipantViewModel disconnectedParticipantViewModel)
        {
            _commonParticipantOperations.RemoveParticipantFromParticipants(disconnectedParticipantViewModel);
        }
    }
}
