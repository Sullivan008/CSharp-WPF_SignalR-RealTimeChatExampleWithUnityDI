using SignalRChatExampleClient.Modules.Common.Services;
using SignalRChatExampleClient.Modules.MainWindow.Interfaces;
using SignalRChatExampleClient.ViewModels;
using System;
using System.Collections.ObjectModel;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Handlers
{
    public class LogoutHandler : ILogoutHandler
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

        public LogoutHandler(ICommonParticipantOperations commonParticipantOperations)
        {
            _commonParticipantOperations = commonParticipantOperations ??
                                           throw new ArgumentNullException(nameof(commonParticipantOperations));
        }

        public ParticipantViewModel GetLoggedOutParticipant(string loggedOutUserName) =>
            _commonParticipantOperations.GetParticipantByUserName(loggedOutUserName);

        public void ClearLoggedOutParticipantChatMessages(ParticipantViewModel loggedOutParticipantViewModel)
        {
            _commonParticipantOperations.ClearChatMessages(loggedOutParticipantViewModel);
        }

        public void RemoveLoggedOutParticipantFromParticipantList(ParticipantViewModel loggedOutParticipantViewModel)
        {
            _commonParticipantOperations.RemoveParticipantFromParticipants(loggedOutParticipantViewModel);
        }
    }
}