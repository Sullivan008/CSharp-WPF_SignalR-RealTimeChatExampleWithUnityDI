using System;
using System.Threading.Tasks;
using Application.Models.RequestModels.SendMessage;
using Application.Models.RequestModels.SignIn;
using Application.Models.ResponseModels.GetParticipants;
using Application.Models.ResponseModels.SignIn;

namespace Application.Client.SignalR.Hubs.Chat.Interfaces
{
    public interface ISignalRChatHub
    {
        bool IsConnected { get; }

        void RegisterHubEvent<TResponseModelType>(string actionName, Action<TResponseModelType> callbackAction);

        void RegisterHubReconnectingEvent(Action callbackAction);

        #region SERVERSIDE SENDING Methods

        Task<SignInResponseModel> SignInAsync(SignInRequestModel requestModel);

        Task SignOutAsync();

        Task<GetParticipantsResponseModel> GetParticipantsAsync();

        Task SendMessageAsync(SendMessageRequestModel requestModel);
        
        #endregion
    }
}
