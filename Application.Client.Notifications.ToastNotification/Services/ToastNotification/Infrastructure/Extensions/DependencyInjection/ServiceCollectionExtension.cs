using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Notification.Wpf;

namespace Application.Client.Notifications.ToastNotification.Services.ToastNotification.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddToastNotificationService(this IServiceCollection @this)
    {
        @this.AddSingleton<INotificationManager, NotificationManager>();
        @this.AddSingleton<IToastNotificationService, ToastNotificationService>();

        return @this;
    }
}