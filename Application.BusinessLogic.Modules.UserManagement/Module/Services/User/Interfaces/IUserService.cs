using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Models;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Interfaces;

public interface IUserService
{
    public UserModel GetUserByNickName(string nickName);

    public UserModel GetUserByConnectionId(string connectionId);

    public IReadOnlyCollection<UserModel> GetUsers();

    public void AddUser(UserModel user);

    public void RemoveUserByNickName(string nickName);

    public void RemoveUserByConnectionId(string connectionId);
}