using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;

namespace Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;

public interface IToastNotificationService
{
    public Task ShowNotification(ShowNotificationOptions notificationOptions);
}