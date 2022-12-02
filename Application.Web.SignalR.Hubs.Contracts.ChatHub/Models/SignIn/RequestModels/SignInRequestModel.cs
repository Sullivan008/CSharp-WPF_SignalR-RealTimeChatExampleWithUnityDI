using Application.Web.SignalR.Core.Hubs.Contracts.Models.RequestModels;
using SullyTech.Guard;

namespace Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;

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