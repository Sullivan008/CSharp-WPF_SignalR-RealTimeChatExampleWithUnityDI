using Notification.Wpf;
using Notification.Wpf.Controls;
using SullyTech.Wpf.Notifications.Toast.Configuration.Models.SubModels.Color;

namespace SullyTech.Wpf.Notifications.Toast.Configuration.Models;

public sealed class ToastNotificationConfiguration
{
    public NotificationPosition MessagePosition { get; init; } = NotificationPosition.TopRight;

    public NotificationTextTrimType DefaultTextTrimType { get; init; } = NotificationTextTrimType.Trim;

    public uint DefaultRowCounts { get; init; } = 2;

    public ColorConfiguration ColorConfiguration { get; init; } = new();
}