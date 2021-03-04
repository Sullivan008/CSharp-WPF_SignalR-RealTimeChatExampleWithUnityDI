using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Application.Client.Core.AppCacheStorage.Models;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Messages;
using Application.Client.Core.AppCacheStorage.Services.Interfaces;
using Application.Client.Core.AppCacheStorage.StaticValues.Enums;
using Application.Client.Views.Chat.Services.Interfaces;
using Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService;

namespace Application.Client.Views.Chat.Services
{
    public class ManageParticipantMessagesService : IManageParticipantMessagesService
    {
        private readonly AppCacheStorageKey _storageKey;

        private readonly IAppCacheStorageService _appCacheStorageService;

        public ManageParticipantMessagesService(IAppCacheStorageService appCacheStorageService)
        {
            _storageKey = AppCacheStorageKey.Messages;
            _appCacheStorageService = appCacheStorageService;
        }

        public void AddNewMessageToParticipant(AddNewMessageToParticipantModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), @"The value cannot be null!");
            }

            MessagesStorageItemDataModel messagesStorageItem = GetMessagesStorageItem();

            AddNewMessageToMessages(messagesStorageItem, model);

            SaveMessagesStorageItem(messagesStorageItem);
        }

        public IEnumerable<MessageItem> GetParticipantMessages(GetParticipantMessagesModel model)
        {
            MessagesStorageItemDataModel messagesStorageItem = GetMessagesStorageItem();

            messagesStorageItem.MessagesDictionary.TryGetValue(model.ParticipantId, out List<MessageItem> result);

            return result ?? new List<MessageItem>();
        }

        public void RemoveSignedOutParticipantMessages(RemoveSignedOutParticipantMessagesModel model)
        {
            MessagesStorageItemDataModel messagesStorageItem = GetMessagesStorageItem();

            if (messagesStorageItem.MessagesDictionary.ContainsKey(model.ParticipantId))
            {
                messagesStorageItem.MessagesDictionary.TryRemove(model.ParticipantId, out _);
               
                SaveMessagesStorageItem(messagesStorageItem);
            }
        }

        public void RemoveDisconnectedParticipantMessages(RemoveDisconnectedParticipantMessagesModel model)
        {
            MessagesStorageItemDataModel messagesStorageItem = GetMessagesStorageItem();

            if (messagesStorageItem.MessagesDictionary.ContainsKey(model.ParticipantId))
            {
                messagesStorageItem.MessagesDictionary.TryRemove(model.ParticipantId, out _);

                SaveMessagesStorageItem(messagesStorageItem);
            }
        }

        #region Common Helper Methods 

        private MessagesStorageItemDataModel GetMessagesStorageItem()
        {
            return _appCacheStorageService.IsStorageKeyExist(_storageKey)
                ? _appCacheStorageService.GetItem<MessagesStorageItemDataModel>(_storageKey)
                : new MessagesStorageItemDataModel(new ConcurrentDictionary<string, List<MessageItem>>());
        }

        #endregion
        
        #region AddNewMessageToParticipant Helper Methods

        private static void AddNewMessageToMessages(MessagesStorageItemDataModel messagesStorageItem, AddNewMessageToParticipantModel model)
        {
            MessageItem messageItem = new MessageItem(model.Message, model.IsOwnMessage, model.PostedTime);

            if (messagesStorageItem.MessagesDictionary.TryGetValue(model.ParticipantId, out List<MessageItem> messages))
            {
                messages.Add(messageItem);
            }
            else
            {
                messagesStorageItem.MessagesDictionary.TryAdd(model.ParticipantId, new List<MessageItem> { messageItem });
            }
        }

        private void SaveMessagesStorageItem(MessagesStorageItemDataModel messagesStorageItem)
        {
            _appCacheStorageService.SetItem(new CacheStorageSaveOptions<MessagesStorageItemDataModel>(_storageKey, messagesStorageItem));
        }

        #endregion
    }
}
