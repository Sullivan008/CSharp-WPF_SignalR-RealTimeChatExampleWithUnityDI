using System;

namespace Application.Client.Core.ViewNavigator.Exceptions
{
    public class SubscriptionToTheViewNavigationNotFoundException : Exception
    {
        public SubscriptionToTheViewNavigationNotFoundException()
        { }

        public SubscriptionToTheViewNavigationNotFoundException(string message) : base(message)
        { }

        public SubscriptionToTheViewNavigationNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
