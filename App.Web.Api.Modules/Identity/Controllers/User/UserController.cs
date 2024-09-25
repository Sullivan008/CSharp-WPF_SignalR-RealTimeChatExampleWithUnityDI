using App.Web.Api.Modules.Identity.Controllers.User.Contracts.SignIn.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SullyTech.Web.Api.Controllers.Api;

namespace App.Web.Api.Modules.Identity.Controllers.User;

[Route($"api/{nameof(Identity)}/[controller]")]
public sealed class UserController : ApiController
{
    public UserController()
    { }

    [HttpPost]
    [AllowAnonymous]
    [Route("SignIn")]
    public async Task<IActionResult> SignIn([FromBody] SignInApiRequestModel requestModel)
    {
        return Ok();
    }
}