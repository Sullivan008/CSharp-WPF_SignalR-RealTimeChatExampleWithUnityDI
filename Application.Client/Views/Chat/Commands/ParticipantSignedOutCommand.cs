using System.Linq;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService;
using Application.Models.HubEventModels;

namespace Application.Client.Views.Chat.ViewModels
{
    public partial class ChatViewModel
    {
        private ICommand _participantSignedOutCommand;
        public ICommand ParticipantSignedOutCommand =>
            _participantSignedOutCommand ?? (_participantSignedOutCommand = new RelayCommandAsync<ParticipantSignedOutHubEventModel>(ExecuteParticipantSignedOutCommand));

        private void ExecuteParticipantSignedOutCommand(ParticipantSignedOutHubEventModel model)
        {
            ParticipantViewModel signedOutParticipant = Participants.Single(x => x.Id == model.Id);

            Participants.Remove(signedOutParticipant);

            _manageParticipantMessagesService.RemoveSignedOutParticipantMessages(new RemoveSignedOutParticipantMessagesModel(model.Id));
        }
    }
}
