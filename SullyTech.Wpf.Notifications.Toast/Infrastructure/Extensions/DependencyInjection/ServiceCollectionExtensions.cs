using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Wpf;
using SullyTech.Wpf.Notifications.Toast.Configuration.Infrastructure.Extensions.DependencyInjection;
using SullyTech.Wpf.Notifications.Toast.Interfaces;

namespace SullyTech.Wpf.Notifications.Toast.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddToastNotification(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.AddToastNotificationConfiguration(configuration);

        @this.AddSingleton<IToastNotification, ToastNotification>();
        @this.AddSingleton<INotificationManager, NotificationManager>();
    }
}