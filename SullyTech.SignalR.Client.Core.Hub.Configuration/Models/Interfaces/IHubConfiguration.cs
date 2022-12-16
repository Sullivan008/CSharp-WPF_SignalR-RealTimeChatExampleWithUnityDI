namespace SullyTech.SignalR.Client.Core.Hub.Configuration.Models.Interfaces;

public interface IHubConfiguration
{
    public string? BaseUrl { get; }

    public int? ReconnectTimeInterval { get; }
}