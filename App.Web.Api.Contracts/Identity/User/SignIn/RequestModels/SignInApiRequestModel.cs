namespace App.Web.Api.Contracts.Identity.User.SignIn.RequestModels;

public sealed class SignInApiRequestModel
{
    public required string UserName { get; init; }

    public required string Password { get; init; }
}