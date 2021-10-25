using System;

namespace Application.Client.SignalR.Hubs.Exceptions
{
    public class AlreadySubscribeToHubEventException : Exception
    {
        public AlreadySubscribeToHubEventException()
        { }

        public AlreadySubscribeToHubEventException(string message) : base(message)
        { }

        public AlreadySubscribeToHubEventException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
