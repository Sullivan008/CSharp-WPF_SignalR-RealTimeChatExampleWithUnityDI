using System;

namespace Application.Server.Repositories.Participant.Exceptions
{
    public class ParticipantNotFoundException : Exception
    {
        public ParticipantNotFoundException()
        { }

        public ParticipantNotFoundException(string message) : base(message)
        { }

        public ParticipantNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
