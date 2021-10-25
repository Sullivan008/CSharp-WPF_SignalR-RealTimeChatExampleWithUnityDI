using System.Collections.Generic;
using Application.Hub.Infrastructure.Configuration.HubConfigurations.Enums;

namespace Application.Hub.Infrastructure.Configuration.HubConfigurations
{
    public class HubConfigurations
    {
        public Dictionary<HubType, string>? Hubs { get; init; }
    }
}
