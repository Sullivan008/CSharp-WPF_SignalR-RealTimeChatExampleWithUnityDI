using System;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Client.SignalR.Hubs.ChatHub.Interfaces;
using Application.Client.SignalR.Infrastructure.Configurations.HubConfigurations;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Client.SignalR.Hubs.ChatHub
{
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
                .WithAutomaticReconnect(new []{new TimeSpan(0,0,0,0,_hubConfigurations.Value.ReconnectTimeInterval!.Value)})
                .Build();
            
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
                catch(HttpRequestException ex)
                {
                    _logger.LogError(ex, ex.Message);

                    await Task.Delay(_hubConfigurations.Value.ReconnectTimeInterval!.Value);
                }
            }
        }
    }
}
