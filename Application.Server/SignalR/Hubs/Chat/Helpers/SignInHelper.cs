using System.Collections.Generic;
using Application.Models.RequestModels.SignIn;
using Application.Server.Repositories.Participant.Interfaces;

namespace Application.Server.SignalR.Hubs.Chat.Helpers
{
    public static class SignInHelper
    {
        public static HashSet<string> SignInValidator(IParticipantRepository participantRepository, SignInRequestModel requestModel)
        {
            HashSet<string> validationErrors = new HashSet<string>();

            ValidateUserName(participantRepository, validationErrors, requestModel.UserName);

            return validationErrors;
        }

        private static void ValidateUserName(IParticipantRepository participantRepository, HashSet<string> validationErrors, string userName)
        {
            if (participantRepository.IsExistingParticipantByName(userName))
            {
                validationErrors.Add($"This username is already exist {userName}");
            }
        }
    }
}
