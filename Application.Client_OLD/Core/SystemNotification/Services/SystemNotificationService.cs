using System;
using System.Windows;
using Application.Client.Core.SystemNotification.Services.Interfaces;
using log4net;

namespace Application.Client.Core.SystemNotification.Services
{
    public class SystemNotificationService : ISystemNotificationService
    {
        private readonly ILog _logger;

        public SystemNotificationService(ILog logger)
        {
            _logger = logger;
        }

        public void ShowError(string content, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Error(content, ex);
            }

            MessageBox.Show(content, nameof(MessageBoxImage.Error), MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        public void ShowWarn(string content, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Warn(content, ex);
            }

            MessageBox.Show(content, nameof(MessageBoxImage.Warning), MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
