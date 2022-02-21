using Application.Common.Utilities.Guard;
using Application.Web.SignalR.Hubs.Contracts.Core.Models.RequestModels;

namespace Application.Web.SignalR.Hubs.Contracts.Implementations.ChatHub.Models.SignIn.RequestModels;

public class SignInRequestModel : SignalRRequestModel
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