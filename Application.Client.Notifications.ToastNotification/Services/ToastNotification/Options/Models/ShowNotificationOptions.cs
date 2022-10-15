using App.Core.Guard.Implementation;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums;

namespace Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;

public class ShowNotificationOptions
{
    private readonly string? _title;
    public string Title
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_title, nameof(Title));

            return _title!;
        }

        init => _title = value;
    }

    private readonly string? _message;
    public string Message
    {
        get
        {
            Guard.ThrowIfNullOrWhitespace(_title, nameof(Message));

            return _message!;
        }

        init => _message = value;
    }

    private readonly NotificationType? _notificationType;
    public NotificationType NotificationType
    {
        get
        {
            Guard.ThrowIfNull(_notificationType, nameof(NotificationType));

            return _notificationType!.Value;
        }

        init => _notificationType = value;
    }
}