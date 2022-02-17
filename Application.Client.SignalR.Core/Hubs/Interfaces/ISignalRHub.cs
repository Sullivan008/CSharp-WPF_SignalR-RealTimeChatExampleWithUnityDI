namespace Application.Client.SignalR.Core.Hubs.Interfaces;

public interface ISignalRHub
{
    public bool IsConnected { get; }
}