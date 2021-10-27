using System;

namespace Application.Web.Hub.Chat.Stores.Participant.Exceptions
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
