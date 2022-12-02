using Application.BusinessLogic.Core.MediatR.Commands.Models.RequestModels;
using SullyTech.Guard;

namespace Application.BusinessLogic.Modules.UserManagement.Module.Commands.SignIn.RequestModel;

public class SignInCommandRequestModel : MediatRCommandRequestModel
{
    private readonly string? _callerHubConnectionId;
    public string CallerHubConnectionId
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_callerHubConnectionId, nameof(CallerHubConnectionId));

            return _callerHubConnectionId!;
        }

        init => _callerHubConnectionId = value;
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