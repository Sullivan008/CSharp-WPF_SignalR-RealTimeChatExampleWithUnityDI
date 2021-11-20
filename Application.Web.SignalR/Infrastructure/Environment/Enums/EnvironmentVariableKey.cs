using System.Runtime.Serialization;

namespace Application.Web.SignalR.Infrastructure.Environment.Enums;

public enum EnvironmentVariableKey
{
    [EnumMember(Value = "ASPNETCORE_ENVIRONMENT")]
    AspNetCoreEnvironment
}