using System;

namespace Application.Client.Core.Environment.Variables.Exceptions
{
    public class MissingEnvironmentVariableException : Exception
    {
        public MissingEnvironmentVariableException()
        { }

        public MissingEnvironmentVariableException(string message) : base(message)
        { }

        public MissingEnvironmentVariableException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
