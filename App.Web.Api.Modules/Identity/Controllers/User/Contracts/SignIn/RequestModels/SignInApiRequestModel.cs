namespace App.Web.Api.Modules.Identity.Controllers.User.Contracts.SignIn.RequestModels;

public sealed class SignInApiRequestModel
{
    public required string UserName { get; init; }

    public required string Password { get; init; }
}