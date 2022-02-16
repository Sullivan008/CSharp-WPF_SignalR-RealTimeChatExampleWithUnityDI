namespace Application.Client.Windows.ToastNotification.Services.ToastNotification.Exceptions;

internal class UnknownNotificationType : Exception
{
    public UnknownNotificationType()
    { }

    public UnknownNotificationType(string message) : base(message)
    { }

    public UnknownNotificationType(string message, Exception innerException) : base(message, innerException)
    { }
}