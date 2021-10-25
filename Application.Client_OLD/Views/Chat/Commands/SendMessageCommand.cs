using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService;
using Application.Models.RequestModels.SendMessage;

namespace Application.Client.Views.Chat.ViewModels
{
    public partial class ChatViewModel
    {
        private ICommand _sendMessageCommand;
        public ICommand SendMessageCommand =>
            _sendMessageCommand ?? (_sendMessageCommand = new RelayCommandAsync(ExecuteSendMessageCommand,
                o => CanExecuteSendMessageCommand(_signalRChatHub.IsConnected, _appUserService.IsAppUserExist(), _selectedParticipant, _message)));

        private static bool CanExecuteSendMessageCommand(bool isConnected, bool isAppUserExisting, ParticipantViewModel selectedParticipant, string message)
        {
            return isConnected && isAppUserExisting && selectedParticipant != null && !string.IsNullOrWhiteSpace(message);
        }

        private async Task ExecuteSendMessageCommand()
        {
            SendMessageRequestModel requestModel = new SendMessageRequestModel(_selectedParticipant.Id, _message, DateTime.Now);

            try
            {
                await _signalRChatHub.SendMessageAsync(requestModel);

                Messages.Add(new MessageViewModel(requestModel.Message, requestModel.PostedTime, true));
                Message = string.Empty;

                _manageParticipantMessagesService.AddNewMessageToParticipant(new AddNewMessageToParticipantModel(requestModel.RecipientId, requestModel.Message, requestModel.PostedTime, true));
            }
            catch (Exception ex)
            {
                _systemNotificationService.ShowError("An error occurred while sending message!", ex);
            }
        }
    }
}
