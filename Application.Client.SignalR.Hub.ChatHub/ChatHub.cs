using Application.Client.SignalR.Hub.ChatHub.Interfaces;
using Application.Client.SignalR.Infrastructure.Configurations.HubConfigurations;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Client.SignalR.Hub.ChatHub;

public class ChatHub : IChatHub
{
    private readonly ILogger<ChatHub> _logger;

    private readonly HubConnection _hubConnection;

    private readonly IOptions<HubConfigurations> _hubConfigurations;

    public bool IsConnected => _hubConnection.State == HubConnectionState.Connected;

    public ChatHub(ILogger<ChatHub> logger, IOptions<HubConfigurations> hubConfigurations)
    {
        _logger = logger;
        _hubConfigurations = hubConfigurations;

        _hubConnection = new HubConnectionBuilder()
            .AddJsonProtocol()
            .WithUrl($"{hubConfigurations.Value.BaseUrl}/{nameof(ChatHub)}")
            .WithAutomaticReconnect()
            .Build();

        _hubConnection.Closed += OnClosedHubConnection;
        _hubConnection.Reconnected += OnReconnectedHubConnection;
        _hubConnection.Reconnecting += OnReconnectingHubConnection;
            
        Task.Run(ConnectAsync).Wait();
    }

    private async Task ConnectAsync()
    {
        while (!IsConnected)
        {
            try
            {
                await _hubConnection.StartAsync();

                break;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, ex.Message);

                await Task.Delay(_hubConfigurations.Value.ReconnectTimeInterval!.Value);
            }
        }
    }

    private async Task OnClosedHubConnection(Exception? ex)
    {
        if (ex != null)
        {
            _logger.LogError(ex, ex.Message);
        }

        await ConnectAsync();

        await Task.CompletedTask;
    }

    private async Task OnReconnectingHubConnection(Exception? ex)
    {
        if (ex != null)
        {
            _logger.LogError(ex, ex.Message);
        }

        await Task.CompletedTask;
    }

    private async Task OnReconnectedHubConnection(string? arg)
    {
        await Task.CompletedTask;
    }
}