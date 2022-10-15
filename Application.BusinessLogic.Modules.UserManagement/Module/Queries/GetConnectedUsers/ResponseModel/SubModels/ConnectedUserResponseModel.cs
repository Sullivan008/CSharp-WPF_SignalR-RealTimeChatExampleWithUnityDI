using App.Core.Guard.Implementation;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Queries.GetConnectedUsers.ResponseModel.SubModels;

public class ConnectedUserResponseModel
{
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