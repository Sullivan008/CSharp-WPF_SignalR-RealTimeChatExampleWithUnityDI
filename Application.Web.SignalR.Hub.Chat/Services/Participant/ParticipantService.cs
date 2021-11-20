using Application.Common.Cache.Infrastructure.Repository.Interfaces;
using Application.Web.SignalR.Cache.DataModels.ChatHub.Participants;
using Application.Web.SignalR.Cache.Keys;
using Application.Web.SignalR.Hub.Chat.Services.Participant.Exceptions;
using Application.Web.SignalR.Hub.Chat.Services.Participant.Interfaces;

namespace Application.Web.SignalR.Hub.Chat.Services.Participant;

public class ParticipantService : IParticipantService
{
    private readonly ICacheRepository<ChatHubCacheKeys, Participants> _participantsCacheRepository;

    public ParticipantService(ICacheRepository<ChatHubCacheKeys, Participants> participantsCacheRepository)
    {
        _participantsCacheRepository = participantsCacheRepository;
    }

    public Models.Participant GetParticipant(string nickName)
    {
        Participants cachedParticipants = _participantsCacheRepository.GetItem();

        if (!cachedParticipants.TryGetValue(nickName, out Cache.DataModels.ChatHub.Participants.Participant? cachedParticipant))
        {
            throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following nickname: '{nickName}'!");
        }

        return new Models.Participant
        {
            ConnectionId = cachedParticipant.ConnectionId,
            NickName = cachedParticipant.NickName
        };
    }

    public Models.Participant GetParticipantByConnectionId(string connectionId)
    {
        Participants cachedParticipants = _participantsCacheRepository.GetItem();
        Cache.DataModels.ChatHub.Participants.Participant? participantDataModel = cachedParticipants.Values.SingleOrDefault(x => x.ConnectionId == connectionId);

        if (participantDataModel == null)
        {
            throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following connection id: '{connectionId}'!");
        }
            
        return new Models.Participant
        {
            ConnectionId = participantDataModel.ConnectionId,
            NickName = participantDataModel.NickName
        };
    }

    public IReadOnlyCollection<Models.Participant> GetParticipants()
    {
        Participants cachedParticipants = _participantsCacheRepository.GetItem();

        return cachedParticipants.Values.Select(x => new Models.Participant
        {
            NickName = x.NickName,
            ConnectionId = x.ConnectionId
        }).ToList();
    }

    public void AddParticipant(Models.Participant participant)
    {
        Participants cachedParticipants = _participantsCacheRepository.GetItem();
        Cache.DataModels.ChatHub.Participants.Participant participantDataModel = new()
        {
            NickName = participant.NickName,
            ConnectionId = participant.ConnectionId
        };

        if (!cachedParticipants.TryAdd(participantDataModel.NickName, participantDataModel))
        {
            throw new ExistedParticipantException($"The participant is already exists with this nickname: {participantDataModel.NickName}");
        }

        _participantsCacheRepository.SetItem(cachedParticipants);
    }

    public void RemoveParticipant(string nickName)
    {
        Participants cachedParticipants = _participantsCacheRepository.GetItem();

        if (!cachedParticipants.TryRemove(nickName, out _))
        {
            throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following nickname: '{nickName}'!");
        }

        _participantsCacheRepository.SetItem(cachedParticipants);
    }

    public void RefreshParticipantConnectionId(string nickName, string connectionId)
    {
        Participants cachedParticipants = _participantsCacheRepository.GetItem();

        if (!cachedParticipants.TryGetValue(nickName, out Cache.DataModels.ChatHub.Participants.Participant? cachedParticipant))
        {
            throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following nickname: '{nickName}'!");
        }

        cachedParticipant.ConnectionId = connectionId;

        cachedParticipants[cachedParticipant.NickName] = cachedParticipant;
        _participantsCacheRepository.SetItem(cachedParticipants);
    }
}