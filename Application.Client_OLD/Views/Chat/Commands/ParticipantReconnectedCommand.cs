using System.Linq;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Models.HubEventModels;

namespace Application.Client.Views.Chat.ViewModels
{
    public partial class ChatViewModel
    {
        private ICommand _participantReconnectedCommand;

        public ICommand ParticipantReconnectedCommand =>
            _participantReconnectedCommand ?? (_participantReconnectedCommand = new RelayCommandAsync<ParticipantReconnectedHubEventModel>(ExecuteParticipantReconnectedCommand));

        private void ExecuteParticipantReconnectedCommand(ParticipantReconnectedHubEventModel model)
        {
            Participants.Single(x => x.Id == model.Id).IsConnected = true;
        }
    }
}
