using System.Windows.Media;
using FontAwesome5;
using Microsoft.Extensions.Options;
using Notification.Wpf;
using Notification.Wpf.Constants;
using SullyTech.Wpf.Notifications.Toast.Configuration.Models;
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

        NotificationConstants.ErrorBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.ErrorColor.Background));
        NotificationConstants.SuccessBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.SuccessColor.Background));
        NotificationConstants.WarningBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.WarningColor.Background));
        NotificationConstants.InformationBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.InformationColor.Background));
    }

    public async Task ShowNotificationAsync(ShowNotificationOptions showNotificationOptions)
    {
        switch (showNotificationOptions.NotificationType)
        {
            case MethodParameters.ShowNotificationOptions.Enums.NotificationType.Error:
                await OnShowErrorNotification(showNotificationOptions.Title, showNotificationOptions.Message);
                break;
            case MethodParameters.ShowNotificationOptions.Enums.NotificationType.Warning:
                await OnShowWarningNotification(showNotificationOptions.Title, showNotificationOptions.Message);
                break;
            case MethodParameters.ShowNotificationOptions.Enums.NotificationType.Success:
                await OnShowSuccessNotification(showNotificationOptions.Title, showNotificationOptions.Message);
                break;
            case MethodParameters.ShowNotificationOptions.Enums.NotificationType.Information:
                await OnShowInformationNotification(showNotificationOptions.Title, showNotificationOptions.Message);
                break;
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(ShowNotificationAsync)} - Operation for following Window Type [Type: {showNotificationOptions.NotificationType}]");
        }
    }

    private async Task OnShowErrorNotification(string title, string message)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(() =>
        {
            NotificationContent notificationContent = new()
            {
                Title = title,
                Message = message,
                Type = NotificationType.Error,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.ErrorColor.Foreground)),
                Icon = new SvgAwesome
                {
                    Icon = EFontAwesomeIcon.Solid_ExclamationCircle,
                    Height = 25,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.ErrorColor.Foreground))
                }
            };

            _notificationManager.Show(notificationContent);
        });
    }

    private async Task OnShowWarningNotification(string title, string message)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(() =>
        {
            NotificationContent notificationContent = new()
            {
                Title = title,
                Message = message,
                Type = NotificationType.Warning,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.WarningColor.Foreground)),
                Icon = new SvgAwesome
                {
                    Icon = EFontAwesomeIcon.Solid_ExclamationTriangle,
                    Height = 25,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.WarningColor.Foreground))
                }
            };

            _notificationManager.Show(notificationContent);
        });
    }

    private async Task OnShowSuccessNotification(string title, string message)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(() =>
        {
            NotificationContent notificationContent = new()
            {
                Title = title,
                Message = message,
                Type = NotificationType.Success,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.SuccessColor.Foreground)),
                Icon = new SvgAwesome
                {
                    Icon = EFontAwesomeIcon.Solid_CheckCircle,
                    Height = 25,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.SuccessColor.Foreground))
                }
            };

            _notificationManager.Show(notificationContent);
        });
    }

    private async Task OnShowInformationNotification(string title, string message)
    {
        await System.Windows.Application.Current.Dispatcher.BeginInvoke(() =>
        {
            NotificationContent notificationContent = new()
            {
                Title = title,
                Message = message,
                Type = NotificationType.Information,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.InformationColor.Foreground)),
                Icon = new SvgAwesome
                {
                    Icon = EFontAwesomeIcon.Solid_InfoCircle,
                    Height = 25,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_toastNotificationConfiguration.ColorConfiguration.InformationColor.Foreground))
                }
            };

            _notificationManager.Show(notificationContent);
        });
    }
}