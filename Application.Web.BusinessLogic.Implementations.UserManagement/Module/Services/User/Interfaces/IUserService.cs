using Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Models;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Interfaces;

public interface IUserService
{
    public UserModel GetUser(string nickName);

    public UserModel GetUserByConnectionId(string connectionId);

    public IReadOnlyCollection<UserModel> GetUsers();

    public void AddUser(UserModel participant);

    public void RemoveUser(string nickName);
}