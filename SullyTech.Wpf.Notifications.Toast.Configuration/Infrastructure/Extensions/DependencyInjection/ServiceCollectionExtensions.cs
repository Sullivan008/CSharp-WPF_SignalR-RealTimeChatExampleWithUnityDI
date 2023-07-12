using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Extensions.Enum;
using SullyTech.Wpf.Notifications.Toast.Configuration.Enums;
using SullyTech.Wpf.Notifications.Toast.Configuration.Models;

namespace SullyTech.Wpf.Notifications.Toast.Configuration.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddToastNotificationConfiguration(this IServiceCollection @this, IConfiguration configuration)
    {
        string? configurationSectionKey = ConfigurationSectionKey.ToastNotificationConfiguration.GetEnumMemberAttrValue();
        Guard.Guard.ThrowIfNullOrWhitespace(configurationSectionKey, nameof(configurationSectionKey));

        IConfigurationSection configurationSection = configuration.GetSection(configurationSectionKey!);

        @this.Configure<ToastNotificationConfiguration>(configurationSection);
    }
}