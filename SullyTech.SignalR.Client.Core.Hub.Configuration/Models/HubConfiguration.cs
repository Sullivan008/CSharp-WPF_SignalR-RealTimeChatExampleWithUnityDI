using SullyTech.SignalR.Client.Core.Hub.Configuration.Models.Interfaces;

namespace SullyTech.SignalR.Client.Core.Hub.Configuration.Models;

public class HubConfiguration : IHubConfiguration
{
    public string? BaseUrl { get; init; }

    public int? ReconnectTimeInterval { get; init; }
}