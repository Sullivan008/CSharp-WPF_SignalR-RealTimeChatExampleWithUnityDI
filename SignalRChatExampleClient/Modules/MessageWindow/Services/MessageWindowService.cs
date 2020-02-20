using SignalRChatExampleClient.Enums;
using SignalRChatExampleClient.Modules.MessageWindow.Interfaces;
using SignalRChatExampleClient.ViewModels.MessageWindow;
using System;
using System.Windows;

namespace SignalRChatExampleClient.Modules.MessageWindow.Services
{
    public class MessageWindowService : IMessageWindowService
    {
        public void ShowMessageWindow(MessageType messageType, string senderName, string message, DateTime messagePostedDateTime)
        {
            Application.Current.Dispatcher?.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                    {
                        Windows.MessageWindow messageWindow = new Windows.MessageWindow
                        {
                            DataContext = new MessageWindowViewModel
                            {
                                SenderName = senderName,
                                MessagePostedTime = messagePostedDateTime,
                                Content = message,
                                WindowTitle = GetWindowTitleByMessageType(messageType),
                                ContentTitle = GetContentTitleByMessageType(messageType)
                            }
                        };

                        messageWindow.ShowDialog();
                    }
                ));
        }

        #region PRIVATE Helper Methods

        private string GetWindowTitleByMessageType(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Broadcast:
                    return "Broadcast Message Window";
                case MessageType.UnicastNotification:
                    return "Unicast Notification Window";
                default:
                    throw new ArgumentOutOfRangeException($@"Switching Type is not exists this method: {nameof(GetWindowTitleByMessageType)}!");
            }
        }

        private string GetContentTitleByMessageType(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Broadcast:
                    return "You have a new Broadcast Message Received";
                case MessageType.UnicastNotification:
                    return "You have a new Unicast Notification Received";
                default:
                    throw new ArgumentOutOfRangeException($@"Switching Type is not exists this method: {nameof(GetContentTitleByMessageType)}!");
            }
        }

        #endregion
    }
}
