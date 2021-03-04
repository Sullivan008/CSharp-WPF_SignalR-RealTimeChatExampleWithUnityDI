using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Messages;
using Application.Client.Core.AppUser.Services.Interfaces;
using Application.Client.Core.Extensions;
using Application.Client.Core.SystemNotification.Services.Interfaces;
using Application.Client.Core.ViewModels;
using Application.Client.SignalR.Hubs.Chat.Interfaces;
using Application.Client.SignalR.Hubs.Chat.StaticValues;
using Application.Client.SignalR.Hubs.Chat.StaticValues.Enums;
using Application.Client.Views.Chat.Services.Interfaces;
using Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService;
using Application.Client.Views.Chat.ViewModels.Interfaces;
using Application.Models.HubEventModels;

namespace Application.Client.Views.Chat.ViewModels
{
    public partial class ChatViewModel : ViewModelBase, IChatViewModel
    {
        private readonly ISignalRChatHub _signalRChatHub;

        private readonly IAppUserService _appUserService;

        private readonly ISystemNotificationService _systemNotificationService;

        private readonly IManageParticipantMessagesService _manageParticipantMessagesService;

        public ChatViewModel(ISignalRChatHub signalRChatHub, IAppUserService appUserService, ISystemNotificationService systemNotificationService, IManageParticipantMessagesService manageParticipantMessagesService)
        {
            _signalRChatHub = signalRChatHub;
            _appUserService = appUserService;
            _systemNotificationService = systemNotificationService;
            _manageParticipantMessagesService = manageParticipantMessagesService;
            
            _signalRChatHub.RegisterHubReconnectingEvent(OnReconnectingCallbackAction);

            _signalRChatHub.RegisterHubEvent<ParticipantSignedInHubEventModel>(HubEventActions.GetHubEventActionName(HubEventActionType.ParticipantSignedIn), ParticipantSignedInCommand.Execute);
            _signalRChatHub.RegisterHubEvent<ParticipantSignedOutHubEventModel>(HubEventActions.GetHubEventActionName(HubEventActionType.ParticipantSignedOut), ParticipantSignedOutCommand.Execute);
            _signalRChatHub.RegisterHubEvent<ParticipantSendMessageHubEventModel>(HubEventActions.GetHubEventActionName(HubEventActionType.ParticipantSendMessage), ProcessParticipantMessageCommand.Execute);
            _signalRChatHub.RegisterHubEvent<ParticipantDisconnectedHubEventModel>(HubEventActions.GetHubEventActionName(HubEventActionType.ParticipantDisconnected), ParticipantDisconnectedCommand.Execute);
            _signalRChatHub.RegisterHubEvent<ParticipantReconnectedHubEventModel>(HubEventActions.GetHubEventActionName(HubEventActionType.ParticipantReconnected), ParticipantReconnectedCommand.Execute);
        }

        #region PROPERTIES GETTERS/ SETTERS

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;

                OnPropertyChanged();
            }
        }

        private ObservableCollection<ParticipantViewModel> _participants = new AsyncObservableCollection<ParticipantViewModel>();
        public ObservableCollection<ParticipantViewModel> Participants
        {
            get => _participants;
            set
            {
                _participants = value;

                OnPropertyChanged();
            }
        }

        private ParticipantViewModel _selectedParticipant;
        public ParticipantViewModel SelectedParticipant
        {
            get => _selectedParticipant;
            set
            {
                _selectedParticipant = value;
                
                Messages.Clear();

                if (_selectedParticipant != null)
                {
                    SelectedParticipant.HasUnreadMessage = false;

                    LoadSelectedParticipantMessages();
                }

                OnPropertyChanged();
            }
        }

        private ObservableCollection<MessageViewModel> _messages = new AsyncObservableCollection<MessageViewModel>();
        public ObservableCollection<MessageViewModel> Messages
        {
            get => _messages;
            set
            {
                _messages = value;

                OnPropertyChanged();
            }
        }

        #endregion

        private void LoadSelectedParticipantMessages()
        {
            IEnumerable<MessageItem> messages =
                _manageParticipantMessagesService.GetParticipantMessages(new GetParticipantMessagesModel(_selectedParticipant.Id));

            foreach (MessageItem message in messages)
            {
                Messages.Add(new MessageViewModel(message.Message, message.PostedTime, message.IsOwnMessage));
            }
        }

        private void OnReconnectingCallbackAction()
        {
            foreach (ParticipantViewModel participant in Participants)
            {
                participant.IsConnected = false;
            }
        }
    }
}
