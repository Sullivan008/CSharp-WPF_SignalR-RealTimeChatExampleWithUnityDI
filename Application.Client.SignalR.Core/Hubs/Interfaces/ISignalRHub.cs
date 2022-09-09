namespace Application.Client.SignalR.Core.Hubs.Interfaces;

public interface ISignalRHub
{
    public bool IsConnected { get; }

    public Func<Exception?, Task>? ConnectionLost { get; set; }

    public Task ConnectAsync();
}