﻿using Application.Web.SignalR.Hubs.Contracts.ChatHub.Enums;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.GetConnectedUsers.ResponseModel;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Configuration.Models;
using SullyTech.App.Client.SignalR.Hubs.ChatHub.Interfaces;
using SullyTech.Extensions.Enum;
using SullyTech.SignalR.Client.Core.Hub.Abstractions;

namespace SullyTech.App.Client.SignalR.Hubs.ChatHub;

public class ChatHub : SignalRHub<ChatHub, ChatHubConfiguration>, IChatHub
{
    public ChatHub(ILogger<ChatHub> logger, IOptions<ChatHubConfiguration> hubConfiguration) : base(logger, hubConfiguration)
    { }

    protected override async Task OnReconnectingHubConnection(Exception? ex)
    {
        await base.OnReconnectingHubConnection(ex);

        await base.OnConnectionLost(ex);
    }

    public async Task SignInAsync(SignInRequestModel requestModel)
    {
        Guard.Guard.ThrowIfNull(requestModel, nameof(requestModel));

        string? invokableMethodName = InvokableMethods.SignIn.GetEnumMemberAttrValue();
        Guard.Guard.ThrowIfNullOrWhitespace(invokableMethodName, nameof(invokableMethodName));

        await HubConnection.InvokeAsync(invokableMethodName!, requestModel);
    }

    public async Task<GetConnectedUsersResponseModel> GetConnectedUsersAsync()
    {
        string? invokableMethodName = InvokableMethods.GetConnectedUsers.GetEnumMemberAttrValue();
        Guard.Guard.ThrowIfNullOrWhitespace(invokableMethodName, nameof(invokableMethodName));

        return await HubConnection.InvokeAsync<GetConnectedUsersResponseModel>(invokableMethodName!);
    }
}