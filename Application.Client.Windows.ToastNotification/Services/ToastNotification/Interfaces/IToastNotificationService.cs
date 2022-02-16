using Application.Client.Windows.ToastNotification.Services.ToastNotification.Options.Models;

namespace Application.Client.Windows.ToastNotification.Services.ToastNotification.Interfaces;

public interface IToastNotificationService
{
    public Task ShowNotification(ShowNotificationOptions notificationOptions);
}