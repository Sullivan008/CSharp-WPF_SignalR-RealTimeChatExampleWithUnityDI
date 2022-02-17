using Application.Common.Utilities.Guard;

namespace Application.Client.SignalR.Configurations.Models;

public class HubConfigurations
{
    private readonly string? _baseUrl;
    public string BaseUrl
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_baseUrl, nameof(BaseUrl));

            return _baseUrl!;
        }

        init => _baseUrl = value;
    }

    private readonly int? _reconnectTimeInterval;
    public int? ReconnectTimeInterval
    {
        get
        {
            Guard.ThrowIfNull(_reconnectTimeInterval, nameof(ReconnectTimeInterval));

            return _reconnectTimeInterval!.Value;
        }

        init => _reconnectTimeInterval = value;
    }
}