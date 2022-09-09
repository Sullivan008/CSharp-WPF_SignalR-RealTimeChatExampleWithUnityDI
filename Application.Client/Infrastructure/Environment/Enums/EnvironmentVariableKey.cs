using System.Runtime.Serialization;

namespace Application.Client.Infrastructure.Environment.Enums;

public enum EnvironmentVariableKey
{
    [EnumMember(Value = "ASPNETCORE_ENVIRONMENT")]
    AspNetCoreEnvironment
}