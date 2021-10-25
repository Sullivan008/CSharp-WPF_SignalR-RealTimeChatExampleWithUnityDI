using System.Linq;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService;
using Application.Models.HubEventModels;

namespace Application.Client.Views.Chat.ViewModels
{
    public partial class ChatViewModel
    {
        private ICommand _processParticipantMessageCommand;
        public ICommand ProcessParticipantMessageCommand =>
            _processParticipantMessageCommand ?? (_processParticipantMessageCommand = new RelayCommandAsync<ParticipantSendMessageHubEventModel>(ProcessParticipantMessageCommandExecute));

        private void ProcessParticipantMessageCommandExecute(ParticipantSendMessageHubEventModel model)
        {
            if (_selectedParticipant == null || _selectedParticipant.Id != model.SenderId)
            {
                Participants.Single(x => x.Id == model.SenderId).HasUnreadMessage = true;
            }

            if (_selectedParticipant != null && _selectedParticipant.Id == model.SenderId)
            {
                Messages.Add(new MessageViewModel(model.Message, model.PostedTime));
            }

            _manageParticipantMessagesService.AddNewMessageToParticipant(new AddNewMessageToParticipantModel(model.SenderId, model.Message, model.PostedTime));
        }
    }
}