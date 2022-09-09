﻿using System.Runtime.Serialization;

namespace Application.Web.Infrastructure.Environment.Enums;

public enum EnvironmentVariableKey
{
    [EnumMember(Value = "ASPNETCORE_ENVIRONMENT")]
    AspNetCoreEnvironment
}