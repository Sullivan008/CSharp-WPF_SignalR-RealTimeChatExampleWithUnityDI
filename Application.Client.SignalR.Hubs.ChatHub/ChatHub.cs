using Application.Client.SignalR.Core.Configurations.Models;
using Application.Client.SignalR.Core.Hubs.Abstractions;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Common.Utilities.Extensions;
using Application.Common.Utilities.Guard;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Enums;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.GetConnectedUsers.ResponseModel;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Client.SignalR.Hubs.ChatHub;

public class ChatHub : SignalRHub<ChatHub>, IChatHub
{
    public ChatHub(ILogger<ChatHub> logger, IOptions<HubConfigurations> hubConfigurations) : base(logger, hubConfigurations)
    { }
    
    protected override async Task OnReconnectingHubConnection(Exception? ex)
    {
        await base.OnReconnectingHubConnection(ex);

        await base.OnConnectionLost(ex);
    }

    public async Task SignInAsync(SignInRequestModel requestModel)
    {
        Guard.ThrowIfNull(requestModel, nameof(requestModel));

        await HubConnection.InvokeAsync(InvokableMethods.SignIn.GetEnumMemberAttrValue(), requestModel);
    }
    
    public async Task<GetConnectedUsersResponseModel> GetConnectedUsersAsync()
    {
        return await HubConnection.InvokeAsync<GetConnectedUsersResponseModel>(InvokableMethods.GetConnectedUsers.GetEnumMemberAttrValue());
    }
}