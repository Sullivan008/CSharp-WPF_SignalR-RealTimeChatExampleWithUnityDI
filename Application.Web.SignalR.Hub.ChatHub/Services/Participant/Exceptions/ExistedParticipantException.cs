namespace Application.Web.SignalR.Hub.ChatHub.Services.Participant.Exceptions;

public class ExistedParticipantException : Exception
{
    public ExistedParticipantException()
    { }

    public ExistedParticipantException(string message) : base(message)
    { }

    public ExistedParticipantException(string message, Exception innerException) : base(message, innerException)
    { }
}