namespace Application.Client.SignalR.Hubs.Chat.StaticValues.Enums
{
    public enum HubEventActionType
    {
        ParticipantSignedIn = 1,
        ParticipantSignedOut = 2,
        ParticipantSendMessage = 3,
        ParticipantDisconnected = 4,
        ParticipantReconnected = 5
    }
}
