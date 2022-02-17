using Application.Client.SignalR.Core.Configurations.Models;
using Application.Client.SignalR.Core.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Client.SignalR.Core.Hubs.Abstractions;

public abstract class SignalRHub<THub> : ISignalRHub 
    where THub : ISignalRHub
{
    protected readonly ILogger<THub> Logger;

    protected readonly HubConnection HubConnection;

    protected readonly HubConfigurations HubConfigurations;
    
    protected SignalRHub(ILogger<THub> logger, IOptions<HubConfigurations> hubConfigurations)
    {
        Logger = logger;
        HubConfigurations = hubConfigurations.Value;

        HubConnection = new HubConnectionBuilder()
            .AddJsonProtocol()
            .WithUrl($"{HubConfigurations.BaseUrl}/{nameof(THub)}")
            .WithAutomaticReconnect()
            .Build();
    }

    bool ISignalRHub.IsConnected => IsConnected;

    protected abstract bool IsConnected { get; }

    protected abstract Task ConnectAsync();

    protected abstract Task OnClosedHubConnection(Exception? ex);

    protected abstract Task OnReconnectingHubConnection(Exception? ex);

    protected abstract Task OnReconnectedHubConnection(string? arg);
}