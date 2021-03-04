using System;

namespace Application.Client.SignalR.Hubs.Models
{
    public class HubConfiguration
    {
        public string HubName { get; }

        public int ReconnectTimeInterval { get; }

        public HubConfiguration(string hubName, int reconnectTimeInterval)
        {
            HubName = !string.IsNullOrWhiteSpace(hubName) ? hubName : throw new ArgumentNullException(nameof(hubName), @"The value cannot be null!");
            ReconnectTimeInterval = reconnectTimeInterval;
        }
    }
}
