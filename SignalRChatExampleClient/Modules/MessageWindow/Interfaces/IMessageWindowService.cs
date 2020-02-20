using SignalRChatExampleClient.Enums;
using System;

namespace SignalRChatExampleClient.Modules.MessageWindow.Interfaces
{
    public interface IMessageWindowService
    {
        void ShowMessageWindow(MessageType messageType, string senderName, string message, DateTime messagePostedDateTime);
    }
}
