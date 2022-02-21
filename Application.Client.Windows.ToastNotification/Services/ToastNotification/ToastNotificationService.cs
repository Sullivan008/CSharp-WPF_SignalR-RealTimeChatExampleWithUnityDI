using System.Windows.Media;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Exceptions;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Interfaces;
using Application.Client.Notifications.ToastNotification.Services.ToastNotification.Options.Models;
using FontAwesome5;
using Notification.Wpf;
using Notification.Wpf.Constants;
using Notification.Wpf.Controls;

namespace Application.Client.Notifications.ToastNotification.Services.ToastNotification;

public class ToastNotificationService : IToastNotificationService
{
    private readonly INotificationManager _notificationManager;

    public ToastNotificationService(INotificationManager notificationManager)
    {
        _notificationManager = notificationManager;

        OnInitNotificationConstants();
    }

    private static void OnInitNotificationConstants()
    {
        NotificationConstants.MessagePosition = NotificationPosition.TopRight;
        NotificationConstants.DefaulTextTrimType = NotificationTextTrimType.Trim;
        NotificationConstants.DefaultRowCounts = 2;

        NotificationConstants.ErrorBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
        NotificationConstants.SuccessBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
        NotificationConstants.WarningBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
        NotificationConstants.InformationBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
    }

    public async Task ShowNotification(ShowNotificationOptions notificationOptions)
    {
        switch (notificationOptions.NotificationType)
        {
            case Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums.NotificationType.Error:
                await OnShowErrorNotification(notificationOptions.Title, notificationOptions.Message);
                break;
            case Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums.NotificationType.Warning:
                await OnShowWarningNotification(notificationOptions.Title, notificationOptions.Message);
                break;
            case Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums.NotificationType.Success:
                await OnShowSuccessNotification(notificationOptions.Title, notificationOptions.Message);
                break;
            case Notifications.ToastNotification.Services.ToastNotification.Options.Models.Enums.NotificationType.Information:
                await OnShowInformationNotification(notificationOptions.Title, notificationOptions.Message);
                break;
            default:
                throw new UnknownNotificationType("An unknown error occurred while reading the notification type!");
        }
    }

    private async Task OnShowErrorNotification(string title, string message)
    {
        NotificationContent notificationContent = new()
        {
            Title = title,
            Message = message,
            Type = NotificationType.Error,
            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B00020")),
            Icon = new SvgAwesome
            {
                Icon = EFontAwesomeIcon.Solid_ExclamationCircle,
                Height = 25,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B00020"))
            }
        };

        _notificationManager.Show(notificationContent);

        await Task.CompletedTask;
    }

    private async Task OnShowWarningNotification(string title, string message)
    {
        NotificationContent notificationContent = new()
        {
            Title = title,
            Message = message,
            Type = NotificationType.Warning,
            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EDBA00")),
            Icon = new SvgAwesome
            {
                Icon = EFontAwesomeIcon.Solid_ExclamationTriangle,
                Height = 25,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EDBA00"))
            }
        };

        _notificationManager.Show(notificationContent);

        await Task.CompletedTask;
    }

    private async Task OnShowSuccessNotification(string title, string message)
    {
        NotificationContent notificationContent = new()
        {
            Title = title,
            Message = message,
            Type = NotificationType.Success,
            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")),
            Icon = new SvgAwesome
            {
                Icon = EFontAwesomeIcon.Solid_CheckCircle,
                Height = 25,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"))
            }
        };

        _notificationManager.Show(notificationContent);

        await Task.CompletedTask;
    }

    private async Task OnShowInformationNotification(string title, string message)
    {
        NotificationContent notificationContent = new()
        {
            Title = title,
            Message = message,
            Type = NotificationType.Information,
            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E88E5")),
            Icon = new SvgAwesome
            {
                Icon = EFontAwesomeIcon.Solid_InfoCircle,
                Height = 25,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E88E5"))
            }
        };

        _notificationManager.Show(notificationContent);

        await Task.CompletedTask;
    }
}