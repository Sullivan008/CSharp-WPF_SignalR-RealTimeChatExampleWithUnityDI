using System;

namespace Application.Models.RequestModels.SignIn
{
    public class SignInRequestModel
    {
        public string UserName { get; }

        public SignInRequestModel(string userName)
        {
            UserName = !string.IsNullOrWhiteSpace(userName) ? userName.Trim() : throw new ArgumentNullException(nameof(userName), @"The value cannot be null!");
        }
    }
}
