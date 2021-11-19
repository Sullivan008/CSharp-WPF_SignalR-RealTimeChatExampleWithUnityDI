using Application.Web.Cache.DataModels.ChatHub;
using Application.Web.Cache.DataModels.ChatHub.Participant;
using Application.Web.Cache.Infrastructure.Repository.Interfaces;
using Application.Web.Hub.Chat.Stores.Participant.Exceptions;
using Application.Web.Hub.Chat.Stores.Participant.Interfaces;

namespace Application.Web.Hub.Chat.Stores.Participant;

public class ParticipantStore : IParticipantStore
{
    private readonly ICacheRepository<ChatHubDataModel> _chatHubCacheRepository;

    public ParticipantStore(ICacheRepository<ChatHubDataModel> chatHubCacheRepository)
    {
        _chatHubCacheRepository = chatHubCacheRepository;
    }

    public Models.Participant GetParticipant(string nickName)
    {
        ChatHubDataModel chatHubDataModel = _chatHubCacheRepository.GetItem();

        if (!chatHubDataModel.Participants.TryGetValue(nickName, out ParticipantDataModel? cachedParticipant))
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
        ChatHubDataModel chatHubDataModel = _chatHubCacheRepository.GetItem();
        ParticipantDataModel? participantDataModel = chatHubDataModel.Participants.Values.SingleOrDefault(x => x.ConnectionId == connectionId);

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
        ChatHubDataModel chatHubDataModel = _chatHubCacheRepository.GetItem();

        return chatHubDataModel.Participants.Values.Select(x => new Models.Participant
        {
            NickName = x.NickName,
            ConnectionId = x.ConnectionId
        }).ToList();
    }

    public void AddParticipant(Models.Participant participant)
    {
        ChatHubDataModel chatHubDataModel = _chatHubCacheRepository.GetItem();
        ParticipantDataModel participantDataModel = new()
        {
            NickName = participant.NickName,
            ConnectionId = participant.ConnectionId
        };

        if (!chatHubDataModel.Participants.TryAdd(participantDataModel.NickName, participantDataModel))
        {
            throw new ExistedParticipantException($"The participant is already exists with this nickname: {participantDataModel.NickName}");
        }

        _chatHubCacheRepository.SetItem(chatHubDataModel);
    }

    public void RemoveParticipant(string nickName)
    {
        ChatHubDataModel chatHubDataModel = _chatHubCacheRepository.GetItem();

        if (!chatHubDataModel.Participants.TryRemove(nickName, out _))
        {
            throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following nickname: '{nickName}'!");
        }

        _chatHubCacheRepository.SetItem(chatHubDataModel);
    }

    public void RefreshParticipantConnectionId(string nickName, string connectionId)
    {
        ChatHubDataModel chatHubDataModel = _chatHubCacheRepository.GetItem();

        if (!chatHubDataModel.Participants.TryGetValue(nickName, out ParticipantDataModel? cachedParticipant))
        {
            throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following nickname: '{nickName}'!");
        }

        cachedParticipant.ConnectionId = connectionId;

        chatHubDataModel.Participants[cachedParticipant.NickName] = cachedParticipant;
        _chatHubCacheRepository.SetItem(chatHubDataModel);
    }
}