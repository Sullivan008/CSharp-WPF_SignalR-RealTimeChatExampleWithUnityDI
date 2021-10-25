using System.Linq;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService;
using Application.Models.HubEventModels;

namespace Application.Client.Views.Chat.ViewModels
{
    public partial class ChatViewModel
    {
        private ICommand _participantDisconnectedCommand;

        public ICommand ParticipantDisconnectedCommand => 
            _participantDisconnectedCommand ?? (_participantDisconnectedCommand = new RelayCommandAsync<ParticipantDisconnectedHubEventModel>(ExecuteParticipantDisconnectedCommand));

        private void ExecuteParticipantDisconnectedCommand(ParticipantDisconnectedHubEventModel model)
        {
            ParticipantViewModel disconnectedParticipant = Participants.Single(x => x.Id == model.Id);

            Participants.Remove(disconnectedParticipant);

            if (_selectedParticipant.Id == model.Id)
            {
                SelectedParticipant = null;
            }

            _manageParticipantMessagesService.RemoveDisconnectedParticipantMessages(new RemoveDisconnectedParticipantMessagesModel(model.Id));
        }
    }
}
