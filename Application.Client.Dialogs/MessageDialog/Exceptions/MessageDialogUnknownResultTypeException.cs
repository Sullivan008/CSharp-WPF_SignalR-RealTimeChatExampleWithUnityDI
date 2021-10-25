using System;

namespace Application.Client.Dialogs.MessageDialog.Exceptions
{
    internal class MessageDialogUnknownResultTypeException : Exception
    {
        public MessageDialogUnknownResultTypeException()
        { }

        public MessageDialogUnknownResultTypeException(string message) : base(message)
        { }

        public MessageDialogUnknownResultTypeException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
