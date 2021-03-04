using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.HubEventModels;
using Application.Models.RequestModels.SendMessage;
using Application.Models.RequestModels.SignIn;
using Application.Models.ResponseModels.GetParticipants;
using Application.Models.ResponseModels.SignIn;
using Application.Server.Repositories.Participant.Interfaces;
using Application.Server.Repositories.Participant.Models;
using Application.Server.SignalR.Hubs.Chat.Helpers;
using Application.Server.SignalR.Hubs.Chat.Interfaces;
using log4net;
using Microsoft.AspNet.SignalR;

namespace Application.Server.SignalR.Hubs.Chat
{
    public class ChatHub : Hub<IChatHub>
    {
        private readonly ILog _logger;

        private readonly IParticipantRepository _participantRepository;

        private string CallerClientId => Context.ConnectionId;

        public ChatHub(ILog logger, IParticipantRepository participantRepository)
        {
            _logger = logger;
            _participantRepository = participantRepository;
        }

        public SignInResponseModel SignIn(SignInRequestModel model)
        {
            HashSet<string> validationResult = SignInHelper.SignInValidator(_participantRepository, model);

            if (validationResult.Any())
            {
                return new SignInResponseModel(false, validationResult);
            }

            Participant participant = new Participant(CallerClientId, model.UserName);
            _participantRepository.AddParticipant(participant);

            Clients.CallerState.UserName = participant.Name;
            Clients.Others.ParticipantSignedIn(new ParticipantSignedInHubEventModel(participant.Id, participant.Name));

            _logger.Info($"{participant.Name} is signed in to the server - ClientId: {CallerClientId}!");

            return new SignInResponseModel();
        }

        public void SignOut()
        {
            _participantRepository.RemoveParticipant(CallerClientId);

            Clients.Others.ParticipantSignedOut(new ParticipantSignedOutHubEventModel(CallerClientId));

            _logger.Info($"{Clients.CallerState.UserName} is signed out to the server - ClientId: {CallerClientId}!");
        }

        public bool IsSignedIn()
        {
            return _participantRepository.IsExistingParticipantById(CallerClientId);
        }
        
        public GetParticipantsResponseModel GetParticipants()
        {
            GetParticipantsResponseModel result = new GetParticipantsResponseModel();

            IEnumerable<Participant> participants = _participantRepository.GetParticipants().Where(x => x.Id != CallerClientId);
            result.Participants.AddRange(participants.Select(x => new ParticipantListItemResponseModel(x.Id, x.Name)).ToList());

            return result;
        }
        
        public void SendMessage(SendMessageRequestModel model)
        {
            Participant participant = _participantRepository.GetParticipant(model.RecipientId);

            Clients.Client(participant.Id).ParticipantSendMessage(new ParticipantSendMessageHubEventModel(CallerClientId, model.Message, model.PostedTime));
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (_participantRepository.IsExistingParticipantById(CallerClientId))
            {
                _participantRepository.RemoveParticipant(CallerClientId);

                Clients.Others.ParticipantDisconnected(new ParticipantDisconnectedHubEventModel(CallerClientId));
            }

            _logger.Info($"{Clients.CallerState.UserName} is disconnected from server - ClientId: {CallerClientId}!");

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Clients.Others.ParticipantReconnected(new ParticipantReconnectedHubEventModel(CallerClientId));

            _logger.Info($"{Clients.CallerState.UserName} is reconnected to server - ClientId: {CallerClientId}!");

            return base.OnReconnected();
        }
    }
}
