using Application.Common.Utilities.Guard;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Models;

public class UserModel
{
    private readonly string? _connectionId;
    public string ConnectionId
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_connectionId, nameof(ConnectionId));

            return _connectionId!;
        }
        init => _connectionId = value;
    }

    private readonly string? _nickName;
    public string NickName
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_nickName, nameof(NickName));

            return _nickName!;
        }

        init => _nickName = value;
    }
}