using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Notifications.Toast.Configuration.Models;

namespace SullyTech.Wpf.Notifications.Toast.Configuration.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddToastNotificationConfiguration(this IServiceCollection @this, IConfiguration configuration)
    {
        const string CONFIGURATION_SECTION_KEY = "ToastNotificationConfiguration";

        IConfigurationSection configurationSection = configuration.GetSection(CONFIGURATION_SECTION_KEY!);

        @this.Configure<ToastNotificationConfiguration>(configurationSection);
    }
}