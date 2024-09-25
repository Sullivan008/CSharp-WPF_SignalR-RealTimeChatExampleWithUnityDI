namespace App.Web.Api.Contracts.Identity.User.SignIn.ResponseModels.SubModels;

public sealed record AccessTokenApiResponseModel
{
    public required string Token { get; init; }

    public required DateTimeOffset ExpirationTime { get; init; }
}