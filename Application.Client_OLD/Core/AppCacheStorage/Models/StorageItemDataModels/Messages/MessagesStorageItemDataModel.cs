using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Interfaces;

namespace Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Messages
{
    public class MessagesStorageItemDataModel : IAppCacheStorageDataModel
    {
        public ConcurrentDictionary<string, List<MessageItem>> MessagesDictionary { get; }

        public MessagesStorageItemDataModel(ConcurrentDictionary<string, List<MessageItem>> messagesDictionary)
        {
            MessagesDictionary = messagesDictionary ?? throw new ArgumentNullException(nameof(messagesDictionary), @"The value cannot be null!");
        }
    }
}
