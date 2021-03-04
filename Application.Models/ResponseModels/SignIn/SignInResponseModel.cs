using System.Collections.Generic;

namespace Application.Models.ResponseModels.SignIn
{
    public class SignInResponseModel
    {
        public bool IsSuccess { get; }

        public HashSet<string> Errors { get; }

        public SignInResponseModel(bool isSuccess = true, HashSet<string> errors = null)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new HashSet<string>();
        }
    }
}
