using SullyTech.Guard;

namespace Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.GetConnectedUsers.ResponseModel.SubModels;

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