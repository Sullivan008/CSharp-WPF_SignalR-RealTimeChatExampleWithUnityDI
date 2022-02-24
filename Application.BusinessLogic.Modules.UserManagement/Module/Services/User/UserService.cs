using System.Collections.Concurrent;
using Application.BusinessLogic.Modules.UserManagement.Module.Cache;
using Application.BusinessLogic.Modules.UserManagement.Module.Cache.Repositories.UserCache.Models.CacheDataModels;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Exceptions;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Interfaces;
using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Models;
using Application.Cache.Core.Collections.CacheData;
using Application.Cache.Core.Collections.CacheData.Interfaces;
using Application.Cache.Core.Repositories.ApplicationCache.Interfaces;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Services.User;

public class UserService : IUserService
{
    private readonly IApplicationCacheRepository<UserManagementCacheKey, UserCacheDataModel> _userCacheRepository;

    public UserService(IApplicationCacheRepository<UserManagementCacheKey, UserCacheDataModel> usersCacheRepository)
    {
        _userCacheRepository = usersCacheRepository;
    }

    public UserModel GetUserByNickName(string nickName)
    {
        ConcurrentDictionary<string, UserCacheDataModel> cachedUsers = new ConcurrentDictionary<string, UserCacheDataModel>(
            _userCacheRepository.GetItems().ToDictionary(x => x.NickName, y => y));

        if (!cachedUsers.TryGetValue(nickName, out UserCacheDataModel? cachedUser))
        {
            throw new UserNotFoundException($"Cannot be found user among users with the following nickname: '{nickName}'!");
        }

        return new UserModel
        {
            NickName = cachedUser.NickName,
            ConnectionId = cachedUser.ConnectionId
        };
    }

    public UserModel GetUserByConnectionId(string connectionId)
    {
        ConcurrentDictionary<string, UserCacheDataModel> cachedUsers = new ConcurrentDictionary<string, UserCacheDataModel>(
            _userCacheRepository.GetItems().ToDictionary(x => x.NickName, y => y));

        if (!cachedUsers.TryGetValue(connectionId, out UserCacheDataModel? cachedUser))
        {
            throw new UserNotFoundException($"Cannot be found user among users with the following connection id: '{connectionId}'!");
        }

        return new UserModel
        {
            NickName = cachedUser.NickName,
            ConnectionId = cachedUser.ConnectionId
        };
    }

    public IReadOnlyCollection<UserModel> GetUsers()
    {
        ICacheDataCollection<UserCacheDataModel> cachedUsers = _userCacheRepository.GetItems();

        return cachedUsers.Select(x => new UserModel
        {
            NickName = x.NickName,
            ConnectionId = x.ConnectionId
        }).ToList();
    }

    public void AddUser(UserModel user)
    {
        ConcurrentDictionary<string, UserCacheDataModel> cachedUsers = new ConcurrentDictionary<string, UserCacheDataModel>(
            _userCacheRepository.GetItems().ToDictionary(x => x.NickName, y => y));

        UserCacheDataModel newCacheUser = new()
        {
            NickName = user.NickName,
            ConnectionId = user.ConnectionId
        };

        if (!cachedUsers.TryAdd(newCacheUser.NickName, newCacheUser))
        {
            throw new ExistingUserException($"The user is already exists with this nickname: {user.NickName}");
        }

        ICacheDataCollection<UserCacheDataModel> upgradedCacheUsers = new CacheDataCollection<UserCacheDataModel>(
            cachedUsers.Select(x => new UserCacheDataModel 
                                    {
                                        NickName = x.Key,
                                        ConnectionId = x.Value.ConnectionId
                                    })
                       .ToList());

        _userCacheRepository.SetItems(upgradedCacheUsers);
    }

    public void RemoveUserByNickName(string nickName)
    {
        ConcurrentDictionary<string, UserCacheDataModel> cachedUsers = new ConcurrentDictionary<string, UserCacheDataModel>(
            _userCacheRepository.GetItems().ToDictionary(x => x.NickName, y => y));

        if (!cachedUsers.TryRemove(nickName, out _))
        {
            throw new UserNotFoundException($"Cannot be found user among users with the following nickname: '{nickName}'!");
        }

        ICacheDataCollection<UserCacheDataModel> upgradedCacheUsers = new CacheDataCollection<UserCacheDataModel>(
            cachedUsers.Select(x => new UserCacheDataModel
                {
                    NickName = x.Key,
                    ConnectionId = x.Value.ConnectionId
                })
                .ToList());

        _userCacheRepository.SetItems(upgradedCacheUsers);
    }

    public void RemoveUserByConnectionId(string connectionId)
    {
        ConcurrentDictionary<string, UserCacheDataModel> cachedUsers = new ConcurrentDictionary<string, UserCacheDataModel>(
            _userCacheRepository.GetItems().ToDictionary(x => x.ConnectionId, y => y));

        if (!cachedUsers.TryRemove(connectionId, out _))
        {
            throw new UserNotFoundException($"Cannot be found user among users with the following connection id: '{connectionId}'!");
        }

        ICacheDataCollection<UserCacheDataModel> upgradedCacheUsers = new CacheDataCollection<UserCacheDataModel>(
            cachedUsers.Select(x => new UserCacheDataModel
                {
                    NickName = x.Key,
                    ConnectionId = x.Value.ConnectionId
                })
                .ToList());

        _userCacheRepository.SetItems(upgradedCacheUsers);
    }
}