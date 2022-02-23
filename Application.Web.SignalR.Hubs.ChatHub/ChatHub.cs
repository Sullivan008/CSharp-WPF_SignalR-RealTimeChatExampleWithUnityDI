﻿using Application.BusinessLogic.Modules.UserManagement.Module.Commands.SignIn;
using Application.BusinessLogic.Modules.UserManagement.Module.Commands.SignIn.RequestModel;
using Application.Web.SignalR.Core.Hubs.Abstractions;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Interfaces;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using MediatR;

namespace Application.Web.SignalR.Hubs.ChatHub;

public class ChatHub : SignalRHub<IChatHub>
{
    private readonly IMediator _mediator;

    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task SignIn(SignInRequestModel requestModel)
    {
        SignInCommandRequestModel commandRequestModel = new()
        {
            NickName = requestModel.NickName,
            CallerHubConnectionId = Context.ConnectionId
        };

        await _mediator.Send(new SignInCommand(commandRequestModel));
    }

    public override async Task OnConnectedAsync()
    {
        await Task.CompletedTask;
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Task.CompletedTask;
    }
}