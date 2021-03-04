using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Client.Core.Commands;
using Application.Client.Core.Extensions;
using Application.Models.ResponseModels.GetParticipants;

namespace Application.Client.Views.Chat.ViewModels
{
    public partial class ChatViewModel
    {
        private ICommand _loadParticipantsCommand;
        public ICommand LoadParticipantsCommand =>
            _loadParticipantsCommand ?? (_loadParticipantsCommand = 
                new RelayCommandAsync(ExecuteLoadParticipantsCommand, o => CanExecuteLoadParticipantsCommand(_signalRChatHub.IsConnected, _appUserService.IsAppUserExist())));

        public bool CanExecuteLoadParticipantsCommand(bool isConnected, bool isAppUserExisting)
        {
            return isConnected && isAppUserExisting;
        }

        private async Task ExecuteLoadParticipantsCommand()
        {
            try
            {
                GetParticipantsResponseModel response = await _signalRChatHub.GetParticipantsAsync();

                Participants = new AsyncObservableCollection<ParticipantViewModel>(
                    response.Participants.Select(x => new ParticipantViewModel(x.Id, x.Name)));
            }
            catch (Exception ex)
            {
                _systemNotificationService.ShowError("An error occurred while querying participants!", ex);
            }
        }
    }
}
