using System.Collections.Generic;

namespace Application.Models.ResponseModels.GetParticipants
{
    public class GetParticipantsResponseModel
    {
        public List<ParticipantListItemResponseModel> Participants { get; }

        public GetParticipantsResponseModel()
        {
            Participants = new List<ParticipantListItemResponseModel>();
        }
    }
}
