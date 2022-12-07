using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;

namespace SullyTech.Wpf.Notifications.Toast.Interfaces;

public interface IToastNotification
{
    public Task ShowNotificationAsync(ShowNotificationOptions showNotificationOptions);
}