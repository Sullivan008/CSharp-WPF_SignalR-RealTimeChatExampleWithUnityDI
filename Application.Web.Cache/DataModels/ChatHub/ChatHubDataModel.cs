using Application.Web.Cache.DataModels.ChatHub.Participant;
using Application.Web.Cache.Infrastructure.Models.Interfaces;
using System.Collections.Concurrent;

namespace Application.Web.Cache.DataModels.ChatHub;

public class ChatHubDataModel : ICacheDataModel
{
    public ConcurrentDictionary<string, ParticipantDataModel> Participants = new();
}