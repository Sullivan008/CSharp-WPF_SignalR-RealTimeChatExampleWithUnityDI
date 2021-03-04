using System;

namespace Application.Client.Core.AppUser.Exceptions
{
    public class AppUserNotExistException : Exception
    {
        public AppUserNotExistException()
        { }

        public AppUserNotExistException(string message) : base(message)
        { }

        public AppUserNotExistException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
