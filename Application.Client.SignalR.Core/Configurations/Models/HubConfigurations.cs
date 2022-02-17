namespace Application.Client.SignalR.Core.Configurations.Models;

public class HubConfigurations
{
    public string? BaseUrl { get; init; }

    public int? ReconnectTimeInterval { get; init; }
}