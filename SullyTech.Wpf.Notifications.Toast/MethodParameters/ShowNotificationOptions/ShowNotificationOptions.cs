using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions.Enums;

namespace SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;

public sealed class ShowNotificationOptions
{
    public required string Title { get; init; }

    public required string Message { get; init; }

    public required NotificationType NotificationType { get; init; }
}