namespace Application.Client.SignalR.Infrastructure.Configurations.HubConfigurations
{
    public class HubConfigurations
    {
        public string? BaseUrl { get; init; }

        public int? ReconnectTimeInterval { get; init; }
    }
}
