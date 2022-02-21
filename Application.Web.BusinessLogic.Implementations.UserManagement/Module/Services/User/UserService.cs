using Application.BusinessLogic.Modules.UserManagement.Module.Cache;
using Application.BusinessLogic.Modules.UserManagement.Module.Cache.Repositories.UserCache.Models.CacheDataModels;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Interfaces;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Models;
using Application.Cache.Repositories.ApplicationCacheRepository.Interfaces;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Services.User;

public class UserService : IUserService
{
    private readonly IApplicationCacheRepository<UserManagementCacheKey, UserCacheDataModel> _userCacheRepository;

    public UserService(IApplicationCacheRepository<UserManagementCacheKey, UserCacheDataModel> usersCacheRepository)
    {
        _userCacheRepository = usersCacheRepository;
    }

    //public UserModel GetParticipant(string nickName)
    //{
    //    Participants cachedParticipants = _participantsCacheRepository.GetItem();

    //    if (!cachedParticipants.TryGetValue(nickName, out Cache.DataModels.ChatHub.Participants.Participant? cachedParticipant))
    //    {
    //        throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following nickname: '{nickName}'!");
    //    }

    //    return new Hub.ChatHub.Services.Participant.Models.Participant
    //    {
    //        ConnectionId = cachedParticipant.ConnectionId,
    //        NickName = cachedParticipant.NickName
    //    };
    //}

    //public Hub.ChatHub.Services.Participant.Models.Participant GetParticipantByConnectionId(string connectionId)
    //{
    //    Participants cachedParticipants = _participantsCacheRepository.GetItem();
    //    Cache.DataModels.ChatHub.Participants.Participant? participantDataModel = cachedParticipants.Values.SingleOrDefault(x => x.ConnectionId == connectionId);

    //    if (participantDataModel == null)
    //    {
    //        throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following connection id: '{connectionId}'!");
    //    }

    //    return new Hub.ChatHub.Services.Participant.Models.Participant
    //    {
    //        ConnectionId = participantDataModel.ConnectionId,
    //        NickName = participantDataModel.NickName
    //    };
    //}

    //public IReadOnlyCollection<Hub.ChatHub.Services.Participant.Models.Participant> GetParticipants()
    //{
    //    Participants cachedParticipants = _participantsCacheRepository.GetItem();

    //    return cachedParticipants.Values.Select(x => new Hub.ChatHub.Services.Participant.Models.Participant
    //    {
    //        NickName = x.NickName,
    //        ConnectionId = x.ConnectionId
    //    }).ToList();
    //}

    //public void AddParticipant(Hub.ChatHub.Services.Participant.Models.Participant participant)
    //{
    //    Participants cachedParticipants = _participantsCacheRepository.GetItem();
    //    Cache.DataModels.ChatHub.Participants.Participant participantDataModel = new()
    //    {
    //        NickName = participant.NickName,
    //        ConnectionId = participant.ConnectionId
    //    };

    //    if (!cachedParticipants.TryAdd(participantDataModel.NickName, participantDataModel))
    //    {
    //        throw new ExistedParticipantException($"The participant is already exists with this nickname: {participantDataModel.NickName}");
    //    }

    //    _participantsCacheRepository.SetItem(cachedParticipants);
    //}

    //public void RemoveParticipant(string nickName)
    //{
    //    Participants cachedParticipants = _participantsCacheRepository.GetItem();

    //    if (!cachedParticipants.TryRemove(nickName, out _))
    //    {
    //        throw new ParticipantNotFoundException($"Cannot be found participant among participants with the following nickname: '{nickName}'!");
    //    }

    //    _participantsCacheRepository.SetItem(cachedParticipants);
    //}
    public UserModel GetUser(string nickName)
    {
        return null;
    }

    public UserModel GetUserByConnectionId(string connectionId)
    {
        return null;
    }

    public IReadOnlyCollection<UserModel> GetUsers()
    {
        return null;
    }

    public void AddUser(UserModel participant)
    {

    }

    public void RemoveUser(string nickName)
    {

    }
}