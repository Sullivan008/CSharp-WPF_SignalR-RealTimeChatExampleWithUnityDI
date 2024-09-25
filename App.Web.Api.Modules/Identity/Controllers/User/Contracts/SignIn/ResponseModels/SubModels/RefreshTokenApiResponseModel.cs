namespace App.Web.Api.Modules.Identity.Controllers.User.Contracts.SignIn.ResponseModels.SubModels;

public sealed class RefreshTokenApiResponseModel
{
    public required string Token { get; init; }

    public required DateTimeOffset ExpirationTime { get; init; }
}