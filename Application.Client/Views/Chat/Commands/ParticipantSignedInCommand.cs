using System.Linq;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Models.HubEventModels;

namespace Application.Client.Views.Chat.ViewModels
{
    public partial class ChatViewModel
    {
        private ICommand _participantSignedInCommand;
        public ICommand ParticipantSignedInCommand =>
            _participantSignedInCommand ?? (_participantSignedInCommand = new RelayCommandAsync<ParticipantSignedInHubEventModel>(ExecuteParticipantSignedInCommand));

        private void ExecuteParticipantSignedInCommand(ParticipantSignedInHubEventModel model)
        {
            if (!Participants.Any(x => x.Id == model.Id))
            {
                Participants.Add(new ParticipantViewModel(model.Id, model.Name));
            }
        }
    }
}
