using Application.Client.SignalR.Core.Configurations.Models;
using Application.Client.SignalR.Core.Hubs.Interfaces;
using Application.Common.Utilities.Guard;
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

        OnValidateHubConfigurations();

        HubConnection = new HubConnectionBuilder()
            .AddJsonProtocol()
            .WithUrl($"{HubConfigurations.BaseUrl}/{typeof(THub).Name}")
            .WithAutomaticReconnect()
            .Build();
    }

    private void OnValidateHubConfigurations()
    {
        Guard.ThrowIfNullOrWhitespace(HubConfigurations.BaseUrl, nameof(HubConfigurations.BaseUrl));
        Guard.ThrowIfNull(HubConfigurations.ReconnectTimeInterval, nameof(HubConfigurations.ReconnectTimeInterval));
    }

    protected abstract bool IsConnected { get; }

    protected abstract Task ConnectAsync();

    protected abstract Task OnClosedHubConnection(Exception? ex);

    protected abstract Task OnReconnectingHubConnection(Exception? ex);

    protected abstract Task OnReconnectedHubConnection(string? arg);
    
    bool ISignalRHub.IsConnected => IsConnected;

    async Task ISignalRHub.ConnectAsync()
    {
        await ConnectAsync();
    }
}