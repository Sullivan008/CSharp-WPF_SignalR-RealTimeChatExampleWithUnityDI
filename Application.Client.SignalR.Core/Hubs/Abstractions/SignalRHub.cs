using Application.Client.SignalR.Core.Configurations.Models;
using Application.Client.SignalR.Core.Hubs.Interfaces;
using Application.Common.Utilities.Guard;
using Application.Web.SignalR.Core.Hubs.Contracts.Models.RequestModels.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Client.SignalR.Core.Hubs.Abstractions;

public abstract class SignalRHub<THub> : ISignalRHub
    where THub : ISignalRHub
{
    private Func<Exception, Task>? _onInvokeAsyncError;
    
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

    protected async Task InvokeAsync<TSignalRRequestModel>(string methodName, TSignalRRequestModel requestModel)
        where TSignalRRequestModel : ISignalRRequestModel
    {
        Guard.ThrowIfNullOrWhitespace(methodName, nameof(methodName));

        try
        {
            await HubConnection.InvokeAsync(methodName, requestModel);
        }
        catch (HubException ex)
        {
            if (_onInvokeAsyncError != null)
            {
                Guard.ThrowIfNull(ex, nameof(ex));

                await _onInvokeAsyncError(ex);
            }
        }
    }

    bool ISignalRHub.IsConnected => IsConnected;

    Func<Exception, Task>? ISignalRHub.OnInvokeAsyncError
    {
        get => _onInvokeAsyncError;
        set => _onInvokeAsyncError = value;
    }
    
    async Task ISignalRHub.ConnectAsync()
    {
        await ConnectAsync();
    }
}