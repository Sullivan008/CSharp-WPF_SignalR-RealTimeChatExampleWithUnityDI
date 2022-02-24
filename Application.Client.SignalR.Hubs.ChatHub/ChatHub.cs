using Application.Client.SignalR.Core.Configurations.Models;
using Application.Client.SignalR.Core.Hubs.Abstractions;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Web.SignalR.Hubs.Contracts.ChatHub.Models.SignIn.RequestModels;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Client.SignalR.Hubs.ChatHub;

public class ChatHub : SignalRHub<ChatHub>, IChatHub
{
    public ChatHub(ILogger<ChatHub> logger, IOptions<HubConfigurations> hubConfigurations) : base(logger, hubConfigurations)
    {
        HubConnection.Closed += OnClosedHubConnection;
        HubConnection.Reconnected += OnReconnectedHubConnection;
        HubConnection.Reconnecting += OnReconnectingHubConnection;
    }

    protected override bool IsConnected => HubConnection.State == HubConnectionState.Connected;
    
    protected override async Task ConnectAsync()
    {
        while (!IsConnected)
        {
            try
            {
                await HubConnection.StartAsync();

                break;
            }
            catch (HttpRequestException ex)
            {
                Logger.LogError(ex, ex.Message);

                await Task.Delay(HubConfigurations.ReconnectTimeInterval!.Value);
            }
        }
    }

    protected override async Task OnClosedHubConnection(Exception? ex)
    {
        if (ex != null)
        {
            Logger.LogError(ex, ex.Message);
        }

        await ConnectAsync();
    }

    protected override async Task OnReconnectedHubConnection(string? arg)
    {
        await Task.CompletedTask;
    }

    protected override async Task OnReconnectingHubConnection(Exception? ex)
    {
        if (ex != null)
        {
            Logger.LogError(ex, ex.Message);
        }

        await Task.CompletedTask;
    }

    public async Task SignInAsync(SignInRequestModel requestModel)
    {
        await InvokeAsync(nameof(Web.SignalR.Hubs.Contracts.ChatHub.Interfaces.IChatHub.SignIn), requestModel);
    }
}