using App.Web.Api.Modules.Identity.Controllers.User.Contracts.SignIn.ResponseModels.SubModels;

namespace App.Web.Api.Modules.Identity.Controllers.User.Contracts.SignIn.ResponseModels;

public sealed class SignInApiResponseModel
{
    public required AccessTokenApiResponseModel AccessToken { get; init; }

    public required RefreshTokenApiResponseModel RefreshToken { get; init; }
}