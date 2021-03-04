using System;

namespace Application.Client.Core.ViewNavigator.Exceptions
{
    public class AlreadySubscribeToTheViewNavigationException : Exception
    {
        public AlreadySubscribeToTheViewNavigationException()
        { }

        public AlreadySubscribeToTheViewNavigationException(string message) : base(message)
        { }

        public AlreadySubscribeToTheViewNavigationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
