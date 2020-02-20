using SignalRChatExampleClient.Enums;
using SignalRChatExampleClient.Models;
using SignalRChatExampleClient.Modules.Common.Services;
using SignalRChatExampleClient.Modules.MainWindow.Interfaces;
using SignalRChatExampleClient.Modules.MessageWindow.Interfaces;
using SignalRChatExampleClient.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SignalRChatExampleClient.ViewModels.MainWindow;

namespace SignalRChatExampleClient.Modules.MainWindow.Handlers
{
    public class MessageHandler : IMessageHandler
    {
        private readonly ICommonParticipantOperations _commonParticipantOperations;
        private readonly IMessageWindowService _messageWindowService;

        public TaskFactory CtxTaskFactory { get; set; }

        private ObservableCollection<ParticipantViewModel> _participants;
        public ObservableCollection<ParticipantViewModel> Participants
        {
            get => _participants;
            set
            {
                _participants = value;
                _commonParticipantOperations.Participants = value;
            }
        }

        public MessageHandler(ICommonParticipantOperations commonParticipantOperations, IMessageWindowService messageWindowService)
        {
            _commonParticipantOperations = commonParticipantOperations ??
                                           throw new ArgumentNullException(nameof(commonParticipantOperations));
            _messageWindowService = messageWindowService ??
                                    throw new ArgumentNullException(nameof(messageWindowService));
        }

        public void SendUnicastMessage(string senderConnectionId, string message, DateTime messagePostedDateTime, ParticipantViewModel selectedParticipantViewModel)
        {
            ParticipantViewModel sender = _commonParticipantOperations.GetParticipantByConnectionId(senderConnectionId);

            CtxTaskFactory.StartNew(() =>
                sender.Messages.Add(new ChatMessage
                {
                    SenderName = sender.Name,
                    Message = message,
                    MessagePostedDateTime = messagePostedDateTime
                })).Wait();

            if (!(selectedParticipantViewModel != null && selectedParticipantViewModel.Name.Equals(sender.Name)))
            {
                CtxTaskFactory.StartNew(() => sender.HasSentNewMessage = true).Wait();
            }
        }

        public void SendBroadcastMessage(string senderConnectionId, string message, DateTime messagePostedDateTime)
        {
            ParticipantViewModel sender = _commonParticipantOperations.GetParticipantByConnectionId(senderConnectionId);

            _messageWindowService.ShowMessageWindow(MessageType.Broadcast, sender.Name, message, messagePostedDateTime);
        }

        public void SendUnicastNotification(string senderConnectionId, string message, DateTime messagePostedDateTime)
        {
            ParticipantViewModel sender = _commonParticipantOperations.GetParticipantByConnectionId(senderConnectionId);

            _messageWindowService.ShowMessageWindow(MessageType.UnicastNotification, sender.Name, message, messagePostedDateTime);
        }
    }
}
