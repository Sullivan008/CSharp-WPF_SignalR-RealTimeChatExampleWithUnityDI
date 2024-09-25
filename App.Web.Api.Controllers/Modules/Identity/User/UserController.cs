using App.BusinessLogic.Modules.Identity.User.Commands.SignIn;
using App.Web.Api.Contracts.Identity.User.SignIn.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SullyTech.Web.Api.Controllers.Api;
using SullyTech.Web.Api.Cqrs.Core.Interfaces;

namespace App.Web.Api.Controllers.Modules.Identity.User;

[Route($"api/{nameof(Identity)}/[controller]")]
public sealed class UserController : ApiController
{
    private readonly IMediator _mediator;

    public UserController(IWebHostEnvironment webHostEnvironment, IMediator mediator) : base(webHostEnvironment)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous] 
    [Route("SignIn")]
    public async Task<IActionResult> SignIn([FromBody] SignInApiRequestModel requestModel)
    {
        //IResult result = await _mediator.Send(new SignInCommand());

        return Ok();
    }
}