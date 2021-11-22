namespace Application.Web.SignalR.Hub.ChatHub.Services.Participant.Exceptions;

public class ParticipantNotFoundException : Exception
{
    public ParticipantNotFoundException()
    { }

    public ParticipantNotFoundException(string message) : base(message)
    { }

    public ParticipantNotFoundException(string message, Exception innerException) : base(message, innerException)
    { }
}