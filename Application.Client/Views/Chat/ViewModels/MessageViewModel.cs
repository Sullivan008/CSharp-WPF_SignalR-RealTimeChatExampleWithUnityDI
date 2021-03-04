using System;
using Application.Client.Core.ViewModels;

namespace Application.Client.Views.Chat.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        public string Message { get; }

        public bool IsOwnMessage { get; }

        public DateTime PostedTime { get; }

        public MessageViewModel(string message, DateTime postedTime, bool isOwnMessage = false)
        {
            Message = !string.IsNullOrWhiteSpace(message) ? message : throw new ArgumentNullException(nameof(message), @"The value cannot be null!");

            IsOwnMessage = isOwnMessage;
            PostedTime = postedTime;
        }
    }
}
