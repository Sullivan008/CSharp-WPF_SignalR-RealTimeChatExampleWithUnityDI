using System;

namespace Application.Server.Repositories.Participant.Exceptions
{
    public class ExistedParticipantException : Exception
    {
        public ExistedParticipantException()
        { }

        public ExistedParticipantException(string message) : base(message)
        { }

        public ExistedParticipantException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
