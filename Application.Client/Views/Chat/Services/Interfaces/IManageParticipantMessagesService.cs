using System.Collections.Generic;
using Application.Client.Core.AppCacheStorage.Models.StorageItemDataModels.Messages;
using Application.Client.Views.Chat.Services.Models.ManageParticipantMessagesService;

namespace Application.Client.Views.Chat.Services.Interfaces
{
    public interface IManageParticipantMessagesService
    {
        void AddNewMessageToParticipant(AddNewMessageToParticipantModel model);

        IEnumerable<MessageItem> GetParticipantMessages(GetParticipantMessagesModel model);

        void RemoveSignedOutParticipantMessages(RemoveSignedOutParticipantMessagesModel model);

        void RemoveDisconnectedParticipantMessages(RemoveDisconnectedParticipantMessagesModel model);
    }
}
