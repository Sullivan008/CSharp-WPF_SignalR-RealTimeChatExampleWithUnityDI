using System.Windows.Media;
using FontAwesome5;
using Microsoft.Extensions.Options;
using Notification.Wpf;
using Notification.Wpf.Constants;
using SullyTech.Wpf.Notifications.Toast.Infrastructure.Configurations.ToastNotification.Models;
using SullyTech.Wpf.Notifications.Toast.Interfaces;
using SullyTech.Wpf.Notifications.Toast.MethodParameters.ShowNotificationOptions;

namespace SullyTech.Wpf.Notifications.Toast;

public class ToastNotification : IToastNotification
{
    private readonly INotificationManager _notificationManager;

    private readonly ToastNotificationConfiguration _toastNotificationConfiguration;

    public ToastNotification(INotificationManager notificationManager, IOptions<ToastNotificationConfiguration> toastNotificationConfigurationOptions)
    {
        _notificationManager = notificationManager;
        _toastNotificationConfiguration = toastNotificationConfigurationOptions.Value;

        InitNotificationConstants();
    }

    private void InitNotificationConstants()
    {
        NotificationConstants.MessagePosition = _toastNotificationConfiguration.MessagePosition;
        NotificationConstants.DefaulTextTrimType = _toastNotificationConfiguration.DefaultTextTrimType;
        NotificationConstants.DefaultRowCounts = _toastNotificationConfiguration.DefaultRowCounts;

        NotificationConstants.ErrorBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Error.Background));
        NotificationConstants.SuccessBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Success.Background));
        NotificationConstants.WarningBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Warning.Background));
        NotificationConstants.InformationBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Information.Background));
    }

    public async Task ShowNotificationAsync(ShowNotificationOptions showNotificationOptions)
    {
        switch (showNotificationOptions.NotificationType)
        {
            case MethodParameters.ShowNotificationOptions.Enums.NotificationType.Error:
                await OnShowErrorNotificationAsync(showNotificationOptions);
                break;
            case MethodParameters.ShowNotificationOptions.Enums.NotificationType.Warning:
                await OnShowWarningNotificationAsync(showNotificationOptions);
                break;
            case MethodParameters.ShowNotificationOptions.Enums.NotificationType.Success:
                await OnShowSuccessNotificationAsync(showNotificationOptions);
                break;
            case MethodParameters.ShowNotificationOptions.Enums.NotificationType.Information:
                await OnShowInformationNotificationAsync(showNotificationOptions);
                break;
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(ShowNotificationAsync)} - Operation for following Window Type [Type: {showNotificationOptions.NotificationType}]");
        }
    }

    private async Task OnShowErrorNotificationAsync(ShowNotificationOptions showNotificationOptions)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(() =>
        {
            NotificationContent notificationContent = new()
            {
                Title = showNotificationOptions.Title,
                Message = showNotificationOptions.Message,
                Type = NotificationType.Error,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Error.Foreground)),
                Icon = new SvgAwesome
                {
                    Icon = EFontAwesomeIcon.Solid_ExclamationCircle,
                    Height = showNotificationOptions.IconHeight,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Error.Foreground))
                }
            };

            _notificationManager.Show(notificationContent);
        });
    }

    private async Task OnShowWarningNotificationAsync(ShowNotificationOptions showNotificationOptions)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(() =>
        {
            NotificationContent notificationContent = new()
            {
                Title = showNotificationOptions.Title,
                Message = showNotificationOptions.Message,
                Type = NotificationType.Warning,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Warning.Foreground)),
                Icon = new SvgAwesome
                {
                    Icon = EFontAwesomeIcon.Solid_ExclamationTriangle,
                    Height = showNotificationOptions.IconHeight,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Warning.Foreground))
                }
            };

            _notificationManager.Show(notificationContent);
        });
    }

    private async Task OnShowSuccessNotificationAsync(ShowNotificationOptions showNotificationOptions)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(() =>
        {
            NotificationContent notificationContent = new()
            {
                Title = showNotificationOptions.Title,
                Message = showNotificationOptions.Message,
                Type = NotificationType.Success,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Success.Foreground)),
                Icon = new SvgAwesome
                {
                    Icon = EFontAwesomeIcon.Solid_CheckCircle,
                    Height = showNotificationOptions.IconHeight,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Success.Foreground))
                }
            };

            _notificationManager.Show(notificationContent);
        });
    }

    private async Task OnShowInformationNotificationAsync(ShowNotificationOptions showNotificationOptions)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(() =>
        {
            NotificationContent notificationContent = new()
            {
                Title = showNotificationOptions.Title,
                Message = showNotificationOptions.Message,
                Type = NotificationType.Information,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Information.Foreground)),
                Icon = new SvgAwesome
                {
                    Icon = EFontAwesomeIcon.Solid_InfoCircle,
                    Height = showNotificationOptions.IconHeight,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.Information.Foreground))
                }
            };

            _notificationManager.Show(notificationContent);
        });
    }
}