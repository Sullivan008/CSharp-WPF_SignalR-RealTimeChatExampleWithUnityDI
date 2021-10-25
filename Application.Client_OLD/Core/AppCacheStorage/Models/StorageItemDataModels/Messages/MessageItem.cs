using System;

namespace Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Messages
{
    public class MessageItem
    {
        public string Message { get; }
        
        public bool IsOwnMessage { get; }

        public DateTime PostedTime { get; }
        
        public MessageItem(string message, bool isOwnMessage, DateTime postedTime)
        {
            Message = !string.IsNullOrWhiteSpace(message) ? message : throw new ArgumentNullException(nameof(message), @"The value cannot be null!");

            PostedTime = postedTime;
            IsOwnMessage = isOwnMessage;
        }
    }
}
