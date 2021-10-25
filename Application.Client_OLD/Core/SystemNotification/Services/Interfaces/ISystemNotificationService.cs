using System;

namespace Application.Client.Core.SystemNotification.Services.Interfaces
{
    public interface ISystemNotificationService
    {
        void ShowError(string content, Exception ex = null);

        void ShowWarn(string content, Exception ex = null);
    }
}
