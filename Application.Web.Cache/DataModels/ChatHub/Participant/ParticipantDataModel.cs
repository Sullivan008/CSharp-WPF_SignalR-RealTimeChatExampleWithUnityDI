using Application.Utilities.Guard;
using Application.Web.Cache.Infrastructure.Models.Interfaces;

namespace Application.Web.Cache.DataModels.ChatHub.Participant
{
    public class ParticipantDataModel : ICacheDataModel
    {
        private string? _connectionId;
        public string ConnectionId
        {
            get
            {
                Guard.ThrowIfNullOrWhitespace(_connectionId, nameof(ConnectionId));

                return _connectionId!;
            }
            set => _connectionId = value;
        }

        private string? _nickName;
        public string NickName
        {
            get
            {
                Guard.ThrowIfNullOrWhitespace(_nickName, nameof(NickName));

                return _nickName!;
            }
            set => _nickName = value;
        }
    }
}
