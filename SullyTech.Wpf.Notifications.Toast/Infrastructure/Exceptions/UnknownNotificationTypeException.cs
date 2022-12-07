﻿namespace SullyTech.Wpf.Notifications.Toast.Infrastructure.Exceptions;

internal sealed class UnknownNotificationTypeException : Exception
{
    public UnknownNotificationTypeException()
    { }

    public UnknownNotificationTypeException(string message) : base(message)
    { }

    public UnknownNotificationTypeException(string message, Exception innerException) : base(message, innerException)
    { }
}