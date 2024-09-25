using App.Web.Api.Contracts.Identity.User.SignIn.ResponseModels.SubModels;

namespace App.Web.Api.Contracts.Identity.User.SignIn.ResponseModels;

public sealed record SignInApiResponseModel
{
    public required AccessTokenApiResponseModel AccessToken { get; init; }

    public required RefreshTokenApiResponseModel RefreshToken { get; init; }
}