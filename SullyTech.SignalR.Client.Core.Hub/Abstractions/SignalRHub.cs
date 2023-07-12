﻿using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SullyTech.SignalR.Client.Core.Hub.Configuration.Models.Interfaces;
using SullyTech.SignalR.Client.Core.Hub.Interfaces;

namespace SullyTech.SignalR.Client.Core.Hub.Abstractions;

public abstract class SignalRHub<THub, THubConfiguration> : ISignalRHub
    where THub : ISignalRHub
    where THubConfiguration : class, IHubConfiguration
{
    protected readonly ILogger<THub> Logger;


    protected readonly HubConnection HubConnection;

    protected readonly IHubConfiguration HubConfigurations;

    protected SignalRHub(ILogger<THub> logger, IOptions<THubConfiguration> hubConfiguration)
    {
        Logger = logger;

        HubConfigurations = hubConfiguration.Value;
        ValidateHubConfiguration();

        HubConnection = new HubConnectionBuilder()
            .AddJsonProtocol()
            .WithUrl($"{HubConfigurations.BaseUrl}/{typeof(THub).Name}")
            .WithAutomaticReconnect()
            .Build();

        HubConnection.Closed += OnClosedHubConnection;
        HubConnection.Reconnected += OnReconnectedHubConnection;
        HubConnection.Reconnecting += OnReconnectingHubConnection;
    }


    private void ValidateHubConfiguration()
    {
        Guard.Guard.ThrowIfNullOrWhitespace(HubConfigurations.BaseUrl, nameof(HubConfigurations.BaseUrl));
        Guard.Guard.ThrowIfNull(HubConfigurations.ReconnectTimeInterval, nameof(HubConfigurations.ReconnectTimeInterval));
    }

    #region PROPERTIES

    protected virtual bool IsConnected => HubConnection.State == HubConnectionState.Connected;

    bool ISignalRHub.IsConnected => IsConnected;


    protected Func<Exception?, Task>? ConnectionLost { get; set; }

    Func<Exception?, Task>? ISignalRHub.ConnectionLost
    {
        get => ConnectionLost;
        set => ConnectionLost = value;
    }

    #endregion

    #region METHODS

    protected virtual async Task ConnectAsync()
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

    async Task ISignalRHub.ConnectAsync()
    {
        await ConnectAsync();
    }

    protected virtual async Task OnConnectionLost(Exception? ex)
    {
        if (ex is not null)
        {
            Logger.LogError(ex, ex.Message);
        }

        if (ConnectionLost != null)
        {
            await ConnectionLost.Invoke(ex);
        }
    }

    protected virtual async Task OnClosedHubConnection(Exception? ex)
    {
        if (ex is not null)
        {
            Logger.LogError(ex, ex.Message);
        }

        await ConnectAsync();
    }

    protected virtual async Task OnReconnectedHubConnection(string? arg)
    {
        await Task.CompletedTask;
    }

    protected virtual async Task OnReconnectingHubConnection(Exception? ex)
    {
        if (ex is not null)
        {
            Logger.LogError(ex, ex.Message);
        }

        await Task.CompletedTask;
    }

    #endregion
}