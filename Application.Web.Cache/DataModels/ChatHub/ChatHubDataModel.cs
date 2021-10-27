using System.Collections.Concurrent;
using Application.Web.Cache.DataModels.ChatHub.Participant;
using Application.Web.Cache.Infrastructure.Models.Interfaces;

namespace Application.Web.Cache.DataModels.ChatHub
{
    public class ChatHubDataModel : ICacheDataModel
    {
        public ConcurrentDictionary<string, ParticipantDataModel> Participants = new();
    }
}
