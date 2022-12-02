using System.Runtime.Serialization;

namespace SullyTech.Guard.Exceptions;

public class ArgumentNotNullException : ArgumentException
{
    public ArgumentNotNullException() { }

    public ArgumentNotNullException(string? message) : base(message) { }

    public ArgumentNotNullException(string? message, Exception? innerException) : base(message, innerException) { }

    public ArgumentNotNullException(string? paramName, string? message) : base(message, paramName) { }

    public ArgumentNotNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}