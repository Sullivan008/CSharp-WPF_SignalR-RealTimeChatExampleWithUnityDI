using System.Configuration;
using Application.Client.Core.Environment.Enums;
using Application.Client.Core.Environment.Services.Interfaces;
using Application.Client.Core.Environment.Variables.Exceptions;
using Application.Client.Core.Environment.Variables.StaticValues;
using Application.Client.Core.Environment.Variables.StaticValues.Enums;

namespace Application.Client.Core.Environment.Services
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentType GetEnvironmentType()
        {
            int environmentTypeCode;

            string environmentVariableKey = EnvironmentVariables.GetEnvironmentVariableKey(EnvironmentVariableKey.EnvironmentType);

            if (int.TryParse(System.Environment.GetEnvironmentVariable(environmentVariableKey), out environmentTypeCode))
            {
                return (EnvironmentType)environmentTypeCode;
            }

            if (int.TryParse(ConfigurationManager.AppSettings[environmentVariableKey], out environmentTypeCode))
            {
                return (EnvironmentType)environmentTypeCode;
            }

            throw new MissingEnvironmentVariableException($"The following Environment Variable does not exist with this key. {nameof(environmentVariableKey).ToUpper()}: {environmentVariableKey}");
        }
    }
}
